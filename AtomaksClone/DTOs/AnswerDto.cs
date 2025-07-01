namespace AtomaksClone.DTOs
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int QuestionId { get; set; }
        public string IconUrl { get; set; } = string.Empty;

    }

    public class CreateAnswerDto
    {
        public string Text { get; set; } = string.Empty;
        public int QuestionId { get; set; }
        public List<ProductImpactDto> ProductImpacts { get; set; } = new List<ProductImpactDto>();
       

    }

    public class UpdateAnswerDto
    {
        public string Text { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;


    }

    public class ProductImpactDto
    {
        public int ProductId { get; set; }
        public int Point { get; set; }
        public string IconUrl { get; set; } = string.Empty;

    }
}
