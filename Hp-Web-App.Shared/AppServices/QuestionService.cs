using Hp_Web_App.Shared.DbContexts;
using Hp_Web_App.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hp_Web_App.Shared.AppServices;

public class QuestionService : IQuestionService
{
    private readonly DbWebAppContext _context;

    public QuestionService(DbWebAppContext context)
    {
        _context = context;
    }

    #region Question
    public async Task<QuestionField> GetQuestionFieldAsync(int id)
    {
        var questionField = await _context.Set<QuestionField>()
            .Include(qf => qf.QuestionFieldType)
            .Include(d => d.Document)
            .Where(qf => qf.Id == id)
            .FirstOrDefaultAsync();
        return questionField ?? new QuestionField();
    }
    public async Task<List<QuestionField>> GetQuestionFieldsAsync()
    {
        var questionFields = await _context.Set<QuestionField>()
            .Include(qf => qf.QuestionFieldType)
            .Include(d => d.Document)
            .ToListAsync();
        return questionFields ?? new List<QuestionField>();
    }
    public async Task<QuestionField> CreateQuestionFieldAsync(QuestionField questionField)
    {
        if (questionField == null)
        {
            return new QuestionField();
        }

        _context.Add(questionField);
        await _context.SaveChangesAsync();
        return questionField;
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
        await _context
            .QuestionValues
            .Where (x => x.Id == id)
            .ExecuteDeleteAsync();
    }
    #endregion

    #region QuestionFieldTypes
    public async Task<List<QuestionFieldType>> GetQuestionFieldTypesAsync()
    {
        var questionFieldTypes = await _context.Set<QuestionFieldType>().ToListAsync();
        return questionFieldTypes ?? new List<QuestionFieldType>();
    }
    #endregion

    #region QuestionValue
    public async Task<List<T>> CreateQuestionValuesAsync<T>(List<T> questionValues) where T : class
    {
        if (questionValues == null)
        {
            return new List<T>();
        }

        _context.AddRange(questionValues);
        await _context.SaveChangesAsync();
        return questionValues;
    }
    #endregion
}