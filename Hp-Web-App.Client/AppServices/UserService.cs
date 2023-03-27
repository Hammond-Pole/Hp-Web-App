namespace Hp_Web_App.Client.AppServices;

public interface IUserService
{
    Task<UserSession>? Login(string email, string password);
}

public class UserService : IUserService
{
    private readonly DbWebAppContext _context;

    public UserService(DbWebAppContext context)
    {
        _context = context;
    }

    public async Task<UserSession>? Login(string email, string password)
    {
        var user = new User();
        var userRole = new UserRole();
        var userSession = new UserSession();

        // find the user where the Email = email and Password = password
        user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email && u.Password == password && u.IsActive == true);

        if (user == null)
        {
            return null;
        }
        else
        {
            userRole = await _context.Set<UserRole>().FirstOrDefaultAsync(u => u.Id == user.UserRoleId);
            // Assign user.Email and user.UserRoleId to userSession.Email and userSession.UserRoleId
            userSession.UserName = user.Email;
            userSession.Role = userRole.Name;

            return userSession;
        }
    }
}
