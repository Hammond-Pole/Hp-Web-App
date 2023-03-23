namespace Hp_Web_App.Client.AppServices
{
    public class DataService : IDataService
    {
        private readonly DbWebAppContext _context;

        public DataService(DbWebAppContext context)
        {
            _context = context;
        }

        #region Document
        public async Task<Document?> GetDocumentAsync(int id) => await _context.FindAsync<Document>(id);
        public async Task<List<Document>?> GetDocumentsAsync() => await _context.Set<Document>().ToListAsync();
        public async Task<Document> CreateDocumentAsync(Document document)
        {
            _context.Add(document);
            await _context.SaveChangesAsync();
            return document;
        }
        public async Task UpdateDocumentAsync(Document document)
        {
            _context.Update(document);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDocumentAsync(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document != null)
            {
                _context.Documents.Remove(document);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region CompanyDocument
        public async Task<List<CompanyDocument>?> GetCompanyDocumentsByDocumentAsync(int documentId) => await _context.Set<CompanyDocument>().Where(c => c.DocumentId == documentId).ToListAsync();
        public async Task<List<CompanyDocument>?> GetCompanyDocumentsByCompanyAsync(int companyId) => await _context.Set<CompanyDocument>().Where(c => c.CompanyId == companyId).ToListAsync();
        public async Task CreateCompanyDocumentAsync(CompanyDocument companyDocument)
        {
            _context.Add(companyDocument);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCompanyDocumentAsync(CompanyDocument companyDocument)
        {
            _context.Remove(companyDocument);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region QuestionDocument

        public async Task<List<QuestionField>?> GetQuestionFieldsByDocumentAsync(int documentId)
        {
            var questionFields = new List<QuestionField>();

            questionFields = await _context.Set<QuestionField>().Where(q => q.DocumentId == documentId).ToListAsync();

            return questionFields;
        }

        #endregion

        #region Company
        public async Task<Company?> GetCompanyAsync(int id) => await _context.FindAsync<Company>(id);
        public async Task<List<Company>?> GetCompaniesAsync() => await _context.Set<Company>().ToListAsync();

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            _context.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }
        public async Task UpdateCompanyAsync(Company company)
        {
            _context.Update(company);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCompanyAsync(Company company)
        {
            _context.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CompanyType>?> GetCompanyTypesAsync() => await _context.Set<CompanyType>().ToListAsync();

        #endregion

        #region User
        public async Task<User?> GetUserAsync(int id) => await _context.FindAsync<User>(id);
        public async Task<User?> GetUserByEmailAsync(string email) => await _context.Set<User>().Where(u => u.Email == email).FirstOrDefaultAsync();
        public async Task<List<User>?> GetUsersAsync()
        {
            var users = new List<User>();

            users = await _context.Set<User>().ToListAsync();

            return users;
        }            
        public async Task<User> CreateUserAsync(User user)
        {
            user.IsActive = true;
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task UpdateUserAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(User user)
        {
            // Do a lookup on the DocumentsAttached and see if the current user has any documents attached to them.
            // If they do, then set the IsActive to false, otherwise delete the user.
            var documentsAttached = await _context.DocumentsAttached.Where(d => d.UserId == user.Id).ToListAsync();
            if (documentsAttached.Count > 0)
            {
                user.IsActive = false;
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        #endregion

        #region UserRoles
        public async Task<List<UserRole>?> GetUserRolesAsync() => await _context.Set<UserRole>().ToListAsync();


        #endregion

        #region Question
        public async Task<QuestionField?> GetQuestionFieldAsync(int id) => await _context.FindAsync<QuestionField>(id);
        public async Task<List<QuestionField>?> GetQuestionFieldsAsync() => await _context.Set<QuestionField>().ToListAsync();

        public async Task<QuestionField> CreateQuestionFieldAsync(QuestionField questionField)
        {
            _context.Add(questionField);
            await _context.SaveChangesAsync();
            return questionField;
        }
        public async Task UpdateQuestionFieldAsync(QuestionField questionField)
        {
            _context.Update(questionField);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteQuestionByIdAsync(int id)
        {
            QuestionField? question = await _context.QuestionFields.FindAsync(id);
            if (question != null)
            {
                _context.QuestionFields.Remove(question);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region QuestionFieldTypes
        public async Task<List<QuestionFieldType>?> GetQuestionFieldTypesAsync()
        {
            _ = new List<QuestionFieldType>();

            List<QuestionFieldType>? questionFieldType = await _context.Set<QuestionFieldType>().ToListAsync();

            return questionFieldType;
        }
        #endregion

        #region QuestionValue
        public async Task AddQuestionValuesAsync(QuestionStringValue questionValues)
        {
            // Add the QuestionStringValue to the database
            _context.Add(questionValues);
            await _context.SaveChangesAsync();
        }
        public async Task AddQuestionValuesAsync(QuestionDateValue questionValues)
        {
            // Add the QuestionStringValue to the database
            _context.Add(questionValues);
            await _context.SaveChangesAsync();
        }
        public async Task AddQuestionValuesAsync(QuestionIntValue questionValues)
        {
            // Add the QuestionStringValue to the database
            _context.Add(questionValues);
            await _context.SaveChangesAsync();
        }
        public async Task AddQuestionValuesAsync(QuestionBitValue questionValues)
        {
            // Add the QuestionStringValue to the database
            _context.Add(questionValues);
            await _context.SaveChangesAsync();
        }
        public async Task AddQuestionValuesAsync(QuestionFloatValue questionValues)
        {
            // Add the QuestionStringValue to the database
            _context.Add(questionValues);
            await _context.SaveChangesAsync();
        }

        public async Task AddQuestionValuesAsync(QuestionMemoValue questionValues)
        {
            // Add the QuestionStringValue to the database
            _context.Add(questionValues);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
