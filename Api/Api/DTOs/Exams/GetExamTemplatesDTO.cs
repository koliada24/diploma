namespace Api.DTOs.Exams
{
    public class GetExamTemplatesDTO
    {
        public Guid Id { get; set; } = Guid.Empty;

        public string Title { get; set; } = string.Empty;

        public int QuestionCount { get; set; } = 0;
    }
}
