using Hp_Web_App.Shared.AppServices;
using Hp_Web_App.Shared.Models;

namespace Hp_Web_App.Shared.Helpers;

public class UserHelper
{
    private readonly IDocumentService _documentService;

    public UserHelper(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    private async Task<List<Document>> LoadUniqueCompanyDocumentsForUserAsync(int companyId)
    {
        var companyDocuments = await _documentService.GetCompanyDocumentsByCompanyAsync(companyId);

        if (companyDocuments == null)
        {
            return new List<Document>();
        }

        var uniqueDocumentIds = new HashSet<int>(companyDocuments.Select(item => item.DocumentId));

        var uniqueDocuments = new List<Document>();

        foreach (var documentId in uniqueDocumentIds)
        {
            var document = await _documentService.GetDocumentAsync(documentId);

            if (document != null)
            {
                uniqueDocuments.Add(document);
            }
        }

        return uniqueDocuments;
    }



}
