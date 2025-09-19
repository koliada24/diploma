namespace Api.Models.Exams
{
    public class AnswerOption
    {
        public string OptionText { get; set; } = string.Empty;

        public bool IsCorrect { get; set; }
    }
}
