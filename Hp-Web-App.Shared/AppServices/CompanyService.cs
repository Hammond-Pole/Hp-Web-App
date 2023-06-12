using Hp_Web_App.Shared.DbContexts;
using Hp_Web_App.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hp_Web_App.Shared.AppServices;
public class CompanyService : ICompanyService
{
    private readonly DbWebAppContext _context;

    public CompanyService(DbWebAppContext context, object value)
    {
        _context = context;
    }

    #region Company
    public async Task<Company> GetCompanyAsync(int id)
    {
        var company = await _context.Set<Company>()
            .Include(c => c.CompanyType)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();            
        
        if (company == null)
        {
            return new Company();
        }
        
        await _context.Entry(company)
            .Collection(c => c.Users)
            .Query()
            .Include(u => u.UserRole)
            .LoadAsync();

        await _context.Entry(company)
            .Collection(d => d.CompanyDocuments)
            .Query()
            .Include(d => d.Document)
            .Include(c => c.Company)
            .LoadAsync();

        return company ?? new Company();
    }
    public async Task<List<Company>> GetCompaniesAsync()
    {
        var companies = await _context.Set<Company>()
            .Include(c => c.CompanyType)
            .ToListAsync();

        if (companies == null || companies.Count == 0)
        {
            return new List<Company>() { };
        }

        foreach (var company in companies)
        {
            await _context.Entry(company)
                .Collection(c => c.Users)
                .Query()
                .Include(u => u.UserRole)
                .LoadAsync();

            await _context.Entry(company)
                .Collection(d => d.CompanyDocuments)
                .Query()
                .Include(d => d.Document)
                .Include(c => c.Company)
                .LoadAsync();
        }

        return companies ?? new List<Company> { };
    }
    public async Task<Company> CreateCompanyAsync(Company company)
    {
        if (company == null)
        {
            return new Company();
        }

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
        return company;
    }
    public async Task UpdateCompanyAsync(Company company)
    {
        if (company == null)
        {
            throw new ArgumentNullException(nameof(company));
        }

        _context.Update(company);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteCompanyAsync(int id)
    {


        await _context
            .Companies
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }
    public async Task<List<CompanyType>> GetCompanyTypesAsync()
    {
        var companyTypes = await _context.Set<CompanyType>().ToListAsync();
        return companyTypes ?? new List<CompanyType>();
    }
    #endregion
}
