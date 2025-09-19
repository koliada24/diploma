namespace Api.Models.Exams
{
    public class SingleChoiceQuestionTemplate : QuestionTemplate
    {
        public List<AnswerOption> AnswerOptions { get; set; } = new();
    }
}
