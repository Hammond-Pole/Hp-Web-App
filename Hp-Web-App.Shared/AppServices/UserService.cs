using Hp_Web_App.Shared.DbContexts;
using Hp_Web_App.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hp_Web_App.Shared.AppServices;

public interface IUserService
{
    Task<User> CreateUser(User user);
    Task<User>? GetUser(int id);
    Task<List<User>?> GetUsers();
    Task UpdateUser(User user);
    Task<UserSession>? Login(string email, string password);
}

public class UserService : IUserService
{
    private readonly DbWebAppContext _context;

    public UserService(DbWebAppContext context)
    {
        _context = context;
    }

    // Create a user receiving the UserModel
    public async Task<User> CreateUser(User user)
    {
        // Add the user to the database
        _context.Add(user);
        // Save the changes
        await _context.SaveChangesAsync();
        // Return the user
        return user;
    }

    public async Task<User>? GetUser(int id)
    {
        var user = new User();

        user = await _context.FindAsync<User>(id);

        return user;
    }

    public async Task<UserSession>? Login(string email, string password)
    {
        var user = new User();
        var userSession = new UserSession();

        // find the user where the Email = email and Password = password
        user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

        if (user == null)
        {
            return null;
        }
        else
        {
            // Assign user.Email and user.Role to userSession.Email and userSession.Role
            userSession.UserName = user.Email;
            userSession.Role = user.Role;

            return userSession;
        }
    }
    public async Task<List<User>?> GetUsers()
    {
        // Get all users from database with async
        var users = await _context.Set<User>().ToListAsync();

        return users;
    }

    public async Task UpdateUser(User user)
    {
        _context.Update(user);
        await _context.SaveChangesAsync();
    }
}
