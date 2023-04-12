using Hp_Web_App.Shared.Authentication;
using Hp_Web_App.Shared.DbContexts;
using Hp_Web_App.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hp_Web_App.Shared.AppServices;

public class UserService : IUserService
{
    private readonly DbWebAppContext _context;
    private readonly IDocumentService _documentService;
    private readonly ICompanyService _companyService;

    public UserService(DbWebAppContext context, IDocumentService documentService, ICompanyService companyService)
    {
        _context = context;
        _documentService = documentService;
        _companyService = companyService;
    }

    public async Task<(UserSession, LoginError)> Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException($"'{nameof(email)}' cannot be null or empty.", nameof(email));
        }
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException($"'{nameof(password)}' cannot be null or empty.", nameof(password));
        }

        var user = await GetUserByEmailAsync(email);

        if (VerifyPassword(password, user.Password))
        {
            var session = new UserSession
            {
                UserName = user.Email,
                Role = user.UserRole.Name,
                CompanyId = user.CompanyId,
                SessionId = Guid.NewGuid()
            };

            return (session, LoginError.None);
        }
        return (new UserSession(), LoginError.InvalidCredentials);
    }

    private static bool VerifyPassword(string typedPassword, string storedPassword)
    {
        if (typedPassword == storedPassword) return true;
        return false;
    }

    #region User
    public async Task<User> GetUserAsync(int id)
    {
        // find user by id and include the UserRole.
        var user = await _context.Set<User>()
            .Include(u => u.UserRole)
            .Include(u => u.Company)
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        return user ?? new User();
    }
    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await _context.Set<User>()
            .Include(u => u.UserRole)
            .Include(u => u.Company)
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();
        return user ?? new User();
    }
    public async Task<List<User>> GetUserByCompanyAsync(int companyId)
    {
        var users = await _context.Set<User>()
            .Where(u => u.CompanyId == companyId)
            .ToListAsync();
        return users ?? new List<User>();
    }
    public async Task<List<User>> GetUsersAsync()
    {
        var users = await _context.Set<User>()
            .Include(u => u.UserRole)
            .Include(u => u.Company)
            .ToListAsync();
        return users ?? new List<User>();
    }
    public async Task<User> CreateUserAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User cannot be null.");
        }

        var existingRole = await GetUserRoleAsync(user.UserRoleId);
        if (existingRole == null)
        {
            throw new ArgumentException("User role cannot be null.");
        }

        var existingCompany = await _companyService.GetCompanyAsync(user.CompanyId);
        if (existingCompany == null)
        {
            throw new ArgumentException("Company cannot be null.");
        }

        if (string.IsNullOrEmpty(existingRole.Name) || string.IsNullOrEmpty(existingCompany.Name))
        {
            throw new Exception("User role or company name cannot be empty.");
        }

        user.IsActive = true;
        user.UserRole = existingRole;
        user.Company = existingCompany;
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task UpdateUserAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        _context.Update(user);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteUserAsync(int id)
    {
        // Do a lookup on the DocumentsAttached and see if the current user has any documents attached to them.
        // If they do, then set the IsActive to false, otherwise delete the user.
        var documentsAttached = await _documentService.GetDocumentsAttachedByUserAsync(id);

        if (documentsAttached.Count == 0)
        {
            await _context
                .Users
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();
        }
        else
        {
            await _context
                .Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(u => u.SetProperty(x => x.IsActive, false));
        }
    }
    #endregion

    #region UserRoles
    public async Task<List<UserRole>> GetUserRolesAsync()
    {
        var userRoles = await _context.Set<UserRole>().ToListAsync();
        return userRoles ?? new List<UserRole>();
    }
    public async Task<UserRole> GetUserRoleAsync(int Id)
    {
        var userRole = await _context.UserRoles.FindAsync(Id);
        return userRole ?? new UserRole();
    }
    #endregion
}
