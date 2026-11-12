using Supabase;

namespace PhotoOrganizer.Services; 
public class UserService(Client client, IDeviceIdService idService) : IUserService {
    public async Task<User> GetCurrentUserAsync() {

        var deviceId = await idService.CreateIdAsync();

        var result = await client
            .From<User>()
            .Where(u => u.DeviceId == deviceId)
            .Get();

        var existing = result.Models.FirstOrDefault();
        if(existing != null)
            return existing;

        var NewUser = new User {

            DeviceId = deviceId,
            CreatedAt = DateTime.UtcNow,
        };

        var insert = await client.From<User>().Insert(NewUser);
        return insert.Models.First();
    }
}
