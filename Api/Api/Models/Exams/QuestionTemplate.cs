namespace Api.Models.Exams
{
    public enum QuestionType
    {
        ShortAnswer,
        LongAnswer,
        MultipleChoice,
        SingleChoice,
    }

    public abstract class QuestionTemplate
    {
        public int Id { get; set; }

        public string QuestionText { get; set; } = string.Empty;

        public QuestionType QuestionType { get; private set; }

        public ExamTemplate? ExamTemplate { get; set; }
    }
}
