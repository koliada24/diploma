using Api.Models.Identity;

namespace Api.Models.Exams
{
    public class ExamTemplate
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<QuestionTemplate> Questions { get; set; } = new();

        public Guid CreatedById { get; set; }

        public User CreatedBy { get; set; } = null!;
    }
}
