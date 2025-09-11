using Api.DTOs.Exams;

namespace Api.Interfaces.Exams
{
    public interface IExamsService
    {
        Task<Guid> CreateExamTemplateAsync(CreateExamTemplateDTO createExamTemplateDTO, Guid userId);

        Task<List<GetExamTemplatesDTO>> GetExamTeplatesAsync(Guid userId);
    }
}
