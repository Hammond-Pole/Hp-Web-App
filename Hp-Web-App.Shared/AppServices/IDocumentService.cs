using Hp_Web_App.Shared.Models;

namespace Hp_Web_App.Shared.AppServices;
public interface IDocumentService
{
    Task<CompanyDocument> CreateCompanyDocumentAsync(CompanyDocument companyDocument);
    Task<Document> CreateDocumentAsync(Document document);
    Task<DocumentsAttached> CreateDocumentsAttachedAsync(DocumentsAttached documentsAttached);
    Task DeleteCompanyDocumentAsync(CompanyDocument companyDocument);
    Task DeleteDocumentAsync(int id);
    Task<List<CompanyDocument>> GetCompanyDocumentsByCompanyAsync(int companyId);
    Task<List<CompanyDocument>> GetCompanyDocumentsByDocumentAsync(int documentId);
    Task<Document> GetDocumentAsync(int id);
    Task<List<Document>> GetDocumentsAsync();
    Task<List<DocumentsAttached>> GetDocumentsAttachedByUserAsync(int userId);
    Task<List<QuestionField>> GetQuestionFieldsByDocumentAsync(int Id);
    Task UpdateDocumentAsync(Document document);
}