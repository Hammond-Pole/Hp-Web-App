
using Hp_Web_App.Shared.DbContexts;
using Hp_Web_App.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hp_Web_App.Shared.AppServices
{
    public interface IQuestionService
    {
        Task<QuestionField> CreateQuestionField(QuestionField questionField);
        Task<QuestionField> GetQuestionField(int id);
        Task<List<QuestionField>> GetQuestionFields();
        Task<List<QuestionField>> GetQuestionFieldsByDocument(int documentId);
        Task<List<QuestionFieldType>> GetQuestionFieldTypes();
        Task UpdateQuestionField(QuestionField questionField);
    }

    public class QuestionService : IQuestionService
    {
        private readonly DbWebAppContext _context;

        public QuestionService(DbWebAppContext context)
        {
            _context = context;
        }

        public async Task<QuestionField> CreateQuestionField(QuestionField questionField)
        {
            _context.Add(questionField);
            await _context.SaveChangesAsync();
            return questionField;
        }

        // Add a GetQuestion
        public async Task<QuestionField> GetQuestionField(int id)
        {
            var questionField = new QuestionField();

            questionField = await _context.FindAsync<QuestionField>(id);

            return questionField;
        }

        // Add a GetQuestions
        public async Task<List<QuestionField>> GetQuestionFields()
        {
            var questionFields = new List<QuestionField>();

            questionFields = await _context.Set<QuestionField>().ToListAsync();

            return questionFields;
        }

        // Get all Questions by document
        public async Task<List<QuestionField>> GetQuestionFieldsByDocument(int documentId)
        {
            var questionFields = new List<QuestionField>();

            questionFields = await _context.Set<QuestionField>().Where(q => q.DocumentId == documentId).ToListAsync();

            return questionFields;
        }

        // Get all QuestionFieldTypes and return it as a list
        public async Task<List<QuestionFieldType>> GetQuestionFieldTypes()
        {
            var questionFieldType = new List<QuestionFieldType>();

            questionFieldType = await _context.Set<QuestionFieldType>().ToListAsync();

            return questionFieldType;
        }

        public async Task UpdateQuestionField(QuestionField questionField)
        {
            _context.Update(questionField);
            await _context.SaveChangesAsync();
        }
        
    }
}
