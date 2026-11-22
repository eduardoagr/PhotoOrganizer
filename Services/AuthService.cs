using Supabase.Gotrue;

using System.Text.Json;

namespace PhotoOrganizer.Services;

public enum AuthProvider {
    Google
}

public class AuthService(Supabase.Client client) : IAuthService {

    private bool isInitialized;

    private const string RedirectUri = "photoorganizer://login-callback";

    public bool IsAuthenticated => client.Auth.CurrentSession?.User is not null;

    public async Task<Profile?> SignInWithProviderAsync(AuthProvider provider) {

        var authProvider = provider switch {
            AuthProvider.Google => Supabase.Gotrue.Constants.Provider.Google,
            _ => Supabase.Gotrue.Constants.Provider.Google
        };

        var authState = await client.Auth.SignIn(authProvider, new SignInOptions {
            FlowType = Supabase.Gotrue.Constants.OAuthFlowType.PKCE,
            RedirectTo = RedirectUri
        });

        var callback = await WebAuthenticator.Default.AuthenticateAsync(
            new WebAuthenticatorOptions {
                Url = authState.Uri,
                CallbackUrl = new Uri(RedirectUri)
            });

        if(!callback.Properties.TryGetValue("code", out var code) ||
            string.IsNullOrWhiteSpace(code))
            return null;

        await client.Auth.ExchangeCodeForSession(authState.PKCEVerifier, code);

        var user = client.Auth.CurrentSession?.User ?? client.Auth.CurrentUser;

        if(user is null || !Guid.TryParse(user.Id, out var userId))
            return null;

        return await GetOrCreateProfileAsync(user, userId);
    }

    private async Task<Profile> GetOrCreateProfileAsync(User user, Guid userId) {

        var response = await client
            .From<Profile>()
            .Where(profile => profile.Id == userId)
            .Get();

        var profile = response.Models.FirstOrDefault();

        if(profile is not null)
            return profile;

        var newProfile = new Profile {
            Id = userId,
            DisplayName = ResolveDisplayName(user),
            Email = ResolveEmail(user)
        };

        var result = await client
            .From<Profile>()
            .Insert(newProfile);

        return result.Models.FirstOrDefault() ?? newProfile;
    }

    private static string? ResolveDisplayName(User user) =>
        GetMetadataString(user, "full_name", "name", "display_name")
        ?? (string.IsNullOrWhiteSpace(user.Email) ? null : user.Email);

    private static string? ResolveEmail(User user) =>
        !string.IsNullOrWhiteSpace(user.Email)
            ? user.Email
            : GetMetadataString(user, "email");

    private static string? GetMetadataString(User user, params string[] keys) =>
        keys.Select(key => user.UserMetadata?.GetValueOrDefault(key))
            .Where(value => value is not null)
            .Select(value => value switch {
                JsonElement json when json.ValueKind == JsonValueKind.String
                    => json.GetString(),
                JsonElement => null,
                _ => value.ToString()
            })
            .FirstOrDefault(value => !string.IsNullOrWhiteSpace(value));

    public async Task InitializeAsync() {

        if(isInitialized)
            return;

        client.Auth.LoadSession();

        await client.InitializeAsync();

        isInitialized = true;
    }

    public async Task<Profile?> GetCurrentProfileAsync() {

        var user = client.Auth.CurrentSession?.User ?? client.Auth.CurrentUser;

        if(user is null || !Guid.TryParse(user.Id, out var userId))
            return null;

        var response = await client
            .From<Profile>()
            .Where(profile => profile.Id == userId)
            .Get();

        return response.Models.FirstOrDefault();
    }
}