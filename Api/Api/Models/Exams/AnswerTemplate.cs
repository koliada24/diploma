namespace Api.Models.Exams
{
    public class AnswerTemplate
    {
        public int Id { get; set; }

        public string Text { get; set; } = string.Empty;

        public bool IsCorrect { get; set; }
    }
}
