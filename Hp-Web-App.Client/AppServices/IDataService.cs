namespace Hp_Web_App.Client.AppServices
{
    public interface IDataService
    {
        Task AddQuestionValuesAsync(QuestionStringValue questionValues);
        Task AddQuestionValuesAsync(QuestionDateValue questionValues);
        Task AddQuestionValuesAsync(QuestionIntValue questionValues);
        Task AddQuestionValuesAsync(QuestionBitValue questionValues);
        Task AddQuestionValuesAsync(QuestionFloatValue questionValues);
        Task AddQuestionValuesAsync(QuestionMemoValue questionValues);
        Task<Company> CreateCompanyAsync(Company company);
        Task CreateCompanyDocumentAsync(CompanyDocument companyDocument);
        Task<Document> CreateDocumentAsync(Document document);
        Task<QuestionField> CreateQuestionFieldAsync(QuestionField questionField);
        Task<User> CreateUserAsync(User user);
        Task DeleteCompanyAsync(Company company);
        Task DeleteCompanyDocumentAsync(CompanyDocument companyDocument);
        Task DeleteDocumentAsync(int id);
        Task DeleteQuestionByIdAsync(int id);
        Task DeleteUserAsync(User user);
        Task<List<Company>?> GetCompaniesAsync();
        Task<Company?> GetCompanyAsync(int id);
        Task<List<CompanyDocument>?> GetCompanyDocumentsByCompanyAsync(int companyId);
        Task<List<CompanyDocument>?> GetCompanyDocumentsByDocumentAsync(int documentId);
        Task<List<CompanyType>?> GetCompanyTypesAsync();
        Task<Document?> GetDocumentAsync(int id);
        Task<List<Document>?> GetDocumentsAsync();
        Task<QuestionField?> GetQuestionFieldAsync(int id);
        Task<List<QuestionField>?> GetQuestionFieldsAsync();
        Task<List<QuestionField>?> GetQuestionFieldsByDocumentAsync(int documentId);
        Task<List<QuestionFieldType>?> GetQuestionFieldTypesAsync();
        Task<User?> GetUserAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<List<UserRole>?> GetUserRolesAsync();
        Task<List<User>?> GetUsersAsync();
        Task UpdateCompanyAsync(Company company);
        Task UpdateDocumentAsync(Document document);
        Task UpdateQuestionFieldAsync(QuestionField questionField);
        Task UpdateUserAsync(User user);
    }
}