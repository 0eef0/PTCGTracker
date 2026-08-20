namespace PTCGTrackerUI.Models;

public interface IUserRepository
{
    public Task<UserModel> GetUserByName(string username);
    public Task<UserModel> GetUserById(int id);
}