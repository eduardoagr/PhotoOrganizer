namespace PhotoOrganizer.Services {

    public class DeviceIdService : IDeviceIdService {

        private const string KEY = "device_id";

        public async Task<string> CreateIdAsync() {

            var id = await SecureStorage.GetAsync(KEY);

            if(string.IsNullOrEmpty(id)) {

                id = Guid.NewGuid().ToString();
                await SecureStorage.SetAsync(KEY, id);
            }

            return id;

        }
    }
}
