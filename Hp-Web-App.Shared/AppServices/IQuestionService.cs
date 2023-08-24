using Hp_Web_App.Shared.Models;

namespace Hp_Web_App.Shared.AppServices;
public interface IQuestionService
{
    Task<List<ListValue>> CreateListValuesAsync(List<ListValue> listValues);
    Task<QuestionField> CreateQuestionFieldAsync(QuestionField questionField);
    Task<List<QuestionValues>> CreateQuestionValuesAsync(List<QuestionValues> questionValues);
    Task DeleteQuestionByIdAsync(int id);
    Task<List<QuestionValues>> GetAllQuestionValuesAsync();
    Task<QuestionField> GetQuestionFieldAsync(int id);
    Task<List<QuestionField>> GetQuestionFieldsAsync();
    Task<List<QuestionField>> GetQuestionFieldsByDocumentAsync(int id);
    Task<QuestionFieldType> GetQuestionFieldTypeAsync(int id);
    Task<List<QuestionFieldType>> GetQuestionFieldTypesAsync();
    Task<List<QuestionValues>> GetQuestionValuesByQuestionFieldIdAsync(int id);
    Task UpdateQuestionFieldAsync(QuestionField questionField);
   // Task <listLGetQuestionValueByQuestionFieldIdAsync(int qfiId);
   Task<List<ListValue>> GetQuestionValueByQuestionFieldIdAsync(int QUEST_FIELD_ID);
}