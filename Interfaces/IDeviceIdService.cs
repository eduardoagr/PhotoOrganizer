namespace PhotoOrganizer.Interfaces;

public interface IDeviceIdService {

    Task<string> CreateIdAsync();
}
