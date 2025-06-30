namespace AtomaksClone.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
    }

    public class CreateQuestionDto
    {
        public string Text { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;

    }

    public class UpdateQuestionDto
    {
        public string Text { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
    }
}
