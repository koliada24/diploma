namespace Api.Models.Exams
{
    public class MultipleChoiceQuestionTemplate : QuestionTemplate
    {
        public List<AnswerOption> AnswerOptions { get; set; } = new();
    }
}