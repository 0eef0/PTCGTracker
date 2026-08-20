using Microsoft.EntityFrameworkCore;

namespace PTCGTrackerUI.Models;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserModel> GetUserByName(string username)
    {
        return await _context.AllUsers.SingleAsync(u => u.username == username);
    }

    public async Task<UserModel> GetUserById(int id)
    {
        return await _context.AllUsers.SingleAsync(u => u.id == id);
    }
}