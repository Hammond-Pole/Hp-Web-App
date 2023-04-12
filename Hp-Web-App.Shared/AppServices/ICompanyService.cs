using Hp_Web_App.Shared.Models;

namespace Hp_Web_App.Shared.AppServices;
public interface ICompanyService
{
    Task<Company> CreateCompanyAsync(Company company);
    Task DeleteCompanyAsync(int Id);
    Task<List<Company>> GetCompaniesAsync();
    Task<Company> GetCompanyAsync(int id);
    Task<List<CompanyType>> GetCompanyTypesAsync();
    Task UpdateCompanyAsync(Company company);
}