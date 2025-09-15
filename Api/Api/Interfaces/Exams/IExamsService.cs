using Api.DTOs.Exams;

namespace Api.Interfaces.Exams
{
    public interface IExamsService
    {
        Task<Guid> CreateExamTemplateAsync(CreateExamTemplateDTO createExamTemplateDTO, Guid userId);
        Task DeleteExamTemplateAsync(Guid templateId);
        Task EditExamTemplateAsync(EditExamTemplateDTO createExamTemplateDTO, Guid templateId);
        Task<List<GetExamTemplatesDTO>> GetExamTeplatesAsync(Guid userId);
        Task<GetExamTemplatesDTO> GetExamTeplatesByIdAsync(Guid templateId);
    }
}
