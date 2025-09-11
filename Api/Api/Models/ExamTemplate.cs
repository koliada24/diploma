namespace Api.Models
{
    public class ExamTemplate
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public List<QuestionTemplate> Questions { get; set; } = new();
    }    
}
