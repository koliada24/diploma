using Api.DTOs.Exams;
using Api.Interfaces.Exams;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class TemplatesController : AppBaseController
    {
        private readonly IExamsService _examsService;

        public TemplatesController(IExamsService examsService)
        {
            _examsService = examsService;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateExamTemplate([FromBody] CreateExamTemplateDTO createExamTemplateDTO)
        {
            var createdExamTemplateId = await _examsService.CreateExamTemplateAsync(createExamTemplateDTO, UserId);

            return Ok(createdExamTemplateId);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetExamTemplatesDTO>>> GetExamTemplates()
        {
            var examTemplates = await _examsService.GetExamTeplatesAsync(UserId);

            return Ok(examTemplates);
        }

        [HttpPut("{templateId}")]
        public async Task<ActionResult> EditExamTemplate([FromBody] EditExamTemplateDTO editExamTemplateDTO, Guid templateId)
        {
            await _examsService.EditExamTemplateAsync(editExamTemplateDTO, templateId);

            return Ok();
        }

        [HttpDelete("{templateId}")]
        public async Task<ActionResult> DeleteExamTemplate(Guid templateId)
        {
            await _examsService.DeleteExamTemplateAsync(templateId);

            return Ok();
        }
    }
}
