using Hp_Web_App.Shared.Models;

namespace Hp_Web_App.Shared.AppServices;
public interface IQuestionService
{
    Task<QuestionField> CreateQuestionFieldAsync(QuestionField questionField);
    Task<List<T>> CreateQuestionValuesAsync<T>(List<T> questionValues) where T : class;
    Task DeleteQuestionByIdAsync(int id);
    Task<QuestionField> GetQuestionFieldAsync(int id);
    Task<List<QuestionField>> GetQuestionFieldsAsync();
    Task<List<QuestionFieldType>> GetQuestionFieldTypesAsync();
    Task UpdateQuestionFieldAsync(QuestionField questionField);
}