using Hp_Web_App.Shared.DbContexts;
using Hp_Web_App.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hp_Web_App.Shared.AppServices;

public class QuestionService : IQuestionService
{
    private readonly DbWebAppContext _context;
    private readonly IDocumentService _documentService;

    public QuestionService(DbWebAppContext context, IDocumentService documentService)
    {
        _context = context;
        _documentService = documentService;
    }

    #region Question
    public async Task<QuestionField> GetQuestionFieldAsync(int id)
    {
        var questionField = await _context.Set<QuestionField>()
            .Include(qf => qf.QuestionFieldType)
            .Include(d => d.Document)
            .Include(lv => lv.ListValues)
            .Where(qf => qf.Id == id)
            .Where(qf => qf.IsVisible == true)
            .FirstOrDefaultAsync();
        return questionField ?? new QuestionField();
    }
    public async Task<List<QuestionField>> GetQuestionFieldsAsync()
    {
        var questionFields = await _context.Set<QuestionField>()
            .Include(qf => qf.QuestionFieldType)
            .Include(d => d.Document)
            .Include(lv => lv.ListValues)
            .Where(qf => qf.IsVisible == true)
            .ToListAsync();
        return questionFields ?? new List<QuestionField>();
    }
    public async Task<List<QuestionField>> GetQuestionFieldsByDocumentAsync(int id)
    {
        var questionFields = await _context.Set<QuestionField>()
            .Include(qf => qf.QuestionFieldType)
            .Include(d => d.Document)
            .Include(lv => lv.ListValues)
            .Where(qf => qf.DocumentId == id)
            .Where(qf => qf.IsVisible == true)
            .ToListAsync();
        return questionFields ?? new List<QuestionField>();
    }

    public async Task<QuestionField> CreateQuestionFieldAsync(QuestionField questionField)
    {
        if (questionField == null)
        {
            return new QuestionField();
        }
        
        var existingQuestionFieldType = await GetQuestionFieldTypeAsync(questionField.QuestionFieldTypeId);
        if (existingQuestionFieldType == null)
        {
            throw new Exception("Field Type has not been set.");
        }

        questionField.QuestionFieldType = existingQuestionFieldType;
        _context.QuestionFields.Add(questionField);
        await _context.SaveChangesAsync();
        return questionField ?? new QuestionField();
    }
    public async Task UpdateQuestionFieldAsync(QuestionField questionField)
    {
        if (questionField == null)
        {
            throw new ArgumentNullException(nameof(questionField));
        }

        _context.Update(questionField);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteQuestionByIdAsync(int id)
    {
        // Find any questionValue records exist.
        var _questionValues = await GetQuestionValuesByQuestionFieldIdAsync(id);

        if (_questionValues.Count == 0)
        {
            await _context
                .QuestionFields
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }
        else
        {
            await _context
                .QuestionFields
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(qf => qf.SetProperty(x => x.IsVisible, false));
        }
    }
    public async Task<List<ListValue>> CreateListValuesAsync(List<ListValue> listValues)
    {
        if (listValues == null)
        {
            throw new ArgumentNullException(nameof(listValues));
        }
        
        await _context.ListValues.AddRangeAsync(listValues);
        await _context.SaveChangesAsync();
        return listValues ?? new List<ListValue>();
    }
    
    #endregion

    #region QuestionFieldTypes
    public async Task<List<QuestionFieldType>> GetQuestionFieldTypesAsync()
    {
        var questionFieldTypes = await _context.Set<QuestionFieldType>().ToListAsync();
        return questionFieldTypes ?? new List<QuestionFieldType>();
    }
    public async Task<QuestionFieldType> GetQuestionFieldTypeAsync(int id)
    {
        var questionFieldType = await _context.Set<QuestionFieldType>()
            .Where(qft => qft.Id == id)
            .FirstOrDefaultAsync();
        return questionFieldType ?? new QuestionFieldType();
    }
    #endregion

    #region QuestionValue
    public async Task<List<QuestionValues>> CreateQuestionValuesAsync(List<QuestionValues> questionValues) 
    {
        if (questionValues == null)
        {
            return new List<QuestionValues>();
        }

        foreach (var questionValue in questionValues)
        {
            var existingDocument = await _context.Documents.FindAsync(questionValue.DocumentId);
            if (existingDocument == null)
            {
                throw new Exception($"DocumentsAttached with ID {questionValue.DocumentsAttachedId} not found.");
            }
            questionValue.Document = existingDocument;

            var existingQuestionField = await _context.QuestionFields.FindAsync(questionValue.QuestionFieldID);
            if (existingQuestionField == null)
            {
                throw new Exception($"QuestionField with ID {questionValue.QuestionFieldID} not found.");
            }
            questionValue.QuestionField = existingQuestionField;

            var existingDocumentAttached = await _context.DocumentsAttached.FindAsync(questionValue.DocumentsAttachedId);
            if ( existingDocumentAttached == null)
            {
                throw new Exception($"DocumentAttached with ID {questionValue.DocumentsAttachedId} not found.");
            }
            questionValue.DocumentsAttached = existingDocumentAttached;
            
        }

        _context.AddRange(questionValues);
        await _context.SaveChangesAsync();
        return questionValues;
    }


    public async Task<List<QuestionValues>> GetQuestionValuesByQuestionFieldIdAsync(int id)
    {
        var questionValues = await _context.Set<QuestionValues>()
            .Where(qv => qv.QuestionFieldID == id)
            .ToListAsync();

        return questionValues ?? new List<QuestionValues>();
    }

    public async Task<List<QuestionValues>> GetAllQuestionValuesAsync()
    {
        var oldQuestionValues = await _context.Set<QuestionValues>()
            .ToListAsync() ;
        return oldQuestionValues ?? new List<QuestionValues>();
    }


    #endregion
}