using Supabase.Gotrue;
using Supabase.Gotrue.Interfaces;

using System.Text.Json;

namespace PhotoOrganizer.Helpers;

public class SupabaseSessionHandler(ISecureStorage storage) : IGotrueSessionPersistence<Session> {

    private const string SessionKey = "photoorganizer_session";

    public void DestroySession() {
        storage.Remove(SessionKey);
    }

    public Session? LoadSession() {
        var json = storage.GetAsync(SessionKey).GetAwaiter().GetResult();

        if(string.IsNullOrWhiteSpace(json))
            return null;

        try {
            return JsonSerializer.Deserialize<Session>(json);
        } catch(JsonException) {
            DestroySession();
            return null;
        }
    }

    public void SaveSession(Session session) {

        var json = JsonSerializer.Serialize(session);

        storage.SetAsync(SessionKey, json).GetAwaiter().GetResult();
    }
}
