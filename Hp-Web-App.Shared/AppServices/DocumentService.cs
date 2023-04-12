using Hp_Web_App.Shared.DbContexts;
using Hp_Web_App.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hp_Web_App.Shared.AppServices;
public class DocumentService : IDocumentService
{
    private readonly DbWebAppContext _context;

    public DocumentService(DbWebAppContext context)
    {
        _context = context;
    }

    #region Document
    public async Task<Document> GetDocumentAsync(int id)
    {
        var document = await _context.Set<Document>()
            .Include(x => x.QuestionFields)
            .ThenInclude(c => c.QuestionFieldType)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
        return document ?? new Document();
    }
    public async Task<List<Document>> GetDocumentsAsync()
    {
        var documents = await _context.Set<Document>()
            .Include(x => x.QuestionFields)
            .ThenInclude(c => c.QuestionFieldType)
            .ToListAsync();
        return documents ?? new List<Document>();
    }
    public async Task<Document> CreateDocumentAsync(Document document)
    {
        if (document == null)
        {
            return new Document();
        }

        _context.Add(document);
        await _context.SaveChangesAsync();
        return document;
    }
    public async Task UpdateDocumentAsync(Document document)
    {
        if (document == null)
        {
            throw new ArgumentNullException(nameof(document));
        }

        _context.Update(document);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteDocumentAsync(int id)
    {
        await _context
            .Documents
            .Where(d => d.Id == id)
            .ExecuteDeleteAsync();
    }
    #endregion

    #region Documents Attached
    public async Task<List<DocumentsAttached>> GetDocumentsAttachedByUserAsync(int userId)
    {
        var documentsAttached = await _context.DocumentsAttached.Where(d => d.UserId == userId).ToListAsync();
        return documentsAttached ?? new List<DocumentsAttached>();
    }
    public async Task<DocumentsAttached> CreateDocumentsAttachedAsync(DocumentsAttached documentsAttached)
    {
        if (documentsAttached == null)
        {
            return new DocumentsAttached();
        }

        _context.Add(documentsAttached);
        await _context.SaveChangesAsync();
        return documentsAttached;
    }
    #endregion

    #region CompanyDocument
    public async Task<List<CompanyDocument>> GetCompanyDocumentsByDocumentAsync(int documentId)
    {
        var companyDocuments = await _context.Set<CompanyDocument>().Where(c => c.DocumentId == documentId).ToListAsync();
        return companyDocuments ?? new List<CompanyDocument>();
    }
    public async Task<List<CompanyDocument>> GetCompanyDocumentsByCompanyAsync(int companyId)
    {
        var companyDocuments = await _context.Set<CompanyDocument>().Where(c => c.CompanyId == companyId).ToListAsync();
        return companyDocuments ?? new List<CompanyDocument>();
    }
    public async Task<CompanyDocument> CreateCompanyDocumentAsync(CompanyDocument companyDocument)
    {
        _context.Add(companyDocument);
        await _context.SaveChangesAsync();
        return companyDocument;
    }
    public async Task DeleteCompanyDocumentAsync(CompanyDocument companyDocument)
    {
        _context.Remove(companyDocument);
        await _context.SaveChangesAsync();
    }
    #endregion

    #region QuestionDocument
    public async Task<List<QuestionField>> GetQuestionFieldsByDocumentAsync(int Id)
    {
        var questionFields = await _context.Set<QuestionField>().Where(q => q.DocumentId == Id).ToListAsync();
        return questionFields ?? new List<QuestionField>();
    }
    #endregion
}
