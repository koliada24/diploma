using Api.Database;
using Api.DTOs.Exams;
using Api.Interfaces.Exams;
using Api.Models.Exams;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Exams
{
    public class ExamsService : IExamsService
    {
        private readonly AppDbContext _db;

        public ExamsService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Guid> CreateExamTemplateAsync(CreateExamTemplateDTO createExamTemplateDTO, Guid userId)
        {
            var newExamTemplateId = Guid.NewGuid();

            var createdExamTemplate = new ExamTemplate
            {
                Id = newExamTemplateId,
                Title = createExamTemplateDTO.Title,
                CreatedById = userId
            };

            _db.ExamTemplates.Add(createdExamTemplate);
            await _db.SaveChangesAsync();

            return newExamTemplateId;
        }

        public async Task<List<GetExamTemplatesDTO>> GetExamTeplatesAsync(Guid userId)
        {
            var examTemplates = await _db.ExamTemplates
                .Where(template => template.CreatedById == userId)
                .Select(template => new GetExamTemplatesDTO
                {
                    Id = template.Id,
                    Title = template.Title,
                    QuestionCount = template.Questions.Count
                })
                .ToListAsync();

            return examTemplates;
        }
    }
}
