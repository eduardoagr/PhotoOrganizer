namespace PhotoOrganizer.Interfaces {

    public interface IAuthService {

        Task InitializeAsync();

        Task<Profile?> SignInWithProviderAsync(AuthProvider provider);

        Task<Profile?> GetCurrentProfileAsync();

        bool IsAuthenticated { get; }
    }
}
