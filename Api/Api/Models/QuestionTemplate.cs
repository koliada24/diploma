namespace Api.Models
{
    public class QuestionTemplate
    {
        public int Id { get; set; }

        public string QuestionText { get; set; } = string.Empty;

        public List<AnswerTemplate> Answers { get; set; } = new();
    }
}
