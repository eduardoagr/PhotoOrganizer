namespace PhotoOrganizer.Interfaces; 

public interface IUserService {

   Task<User> GetCurrentUserAsync();
}
