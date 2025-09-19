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
                Description = createExamTemplateDTO.Description,
                CreatedById = userId
            };

            _db.ExamTemplates.Add(createdExamTemplate);
            await _db.SaveChangesAsync();

            return newExamTemplateId;
        }

        public async Task DeleteExamTemplateAsync(Guid templateId)
        {
            var examTemplateToDelete = await _db.ExamTemplates.FirstOrDefaultAsync(x => x.Id == templateId);

            _db.ExamTemplates.Remove(examTemplateToDelete);

            await _db.SaveChangesAsync();
        }

        public async Task EditExamTemplateAsync(EditExamTemplateDTO createExamTemplateDTO, Guid templateId)
        {
            var examTemplateToUpdate = await _db.ExamTemplates.FirstOrDefaultAsync(x => x.Id == templateId);

            examTemplateToUpdate.Title = createExamTemplateDTO.Title;
            examTemplateToUpdate.Description = createExamTemplateDTO.Description;

            await _db.SaveChangesAsync();
        }

        public async Task<List<GetExamTemplateDTO>> GetExamTeplatesAsync(Guid userId)
        {
            var examTemplates = await _db.ExamTemplates
                .Where(template => template.CreatedById == userId)
                .Select(template => new GetExamTemplateDTO
                {
                    Id = template.Id,
                    Title = template.Title,
                    Description = template.Description,
                    QuestionCount = template.Questions.Count
                })
                .ToListAsync();

            return examTemplates;
        }

        public async Task<GetExamTemplateDTO> GetExamTeplatesByIdAsync(Guid templateId)
        {
            var examTemplate = await _db.ExamTemplates
                .Where(template => template.Id == templateId)
                .Select(template => new GetExamTemplateDTO
                {
                    Id = template.Id,
                    Title = template.Title,
                    Description = template.Description,
                    QuestionCount = template.Questions.Count
                })
                .FirstAsync();

            return examTemplate;
        }
    }
}
