using System.ComponentModel.DataAnnotations;

namespace AtomaksClone.DTOs
{
    public class QuizSubmitDto
    {
        [Required(ErrorMessage = "En az bir cevap seçilmelidir")]
        [MinLength(1, ErrorMessage = "En az bir cevap seçilmelidir")]
        public List<int> AnswerIds { get; set; } = new List<int>();
    }

    public class ProductRecommendationDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int TotalScore { get; set; }
    }
}
