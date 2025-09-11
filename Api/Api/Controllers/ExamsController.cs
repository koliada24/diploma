using Api.DTOs.Exams;
using Api.Interfaces.Exams;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ExamsController : AppBaseController
    {
        private readonly IExamsService _examsService;

        public ExamsController(IExamsService examsService)
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
    }
}
