using Hp_Web_App.Shared.Authentication;
using Hp_Web_App.Shared.Models;

namespace Hp_Web_App.Shared.AppServices;
public interface IUserService
{
    Task<User> CreateUserAsync(User user);
    Task DeleteUserAsync(int Id);
    Task<User> GetUserAsync(int id);
    Task<List<User>> GetUserByCompanyAsync(int companyId);
    Task<User> GetUserByEmailAsync(string email);
    Task<UserRole> GetUserRoleAsync(int Id);
    Task<List<UserRole>> GetUserRolesAsync();
    Task<List<User>> GetUsersAsync();
    Task<(UserSession, LoginError)> Login(string email, string password);
    Task UpdateUserAsync(User user);
}