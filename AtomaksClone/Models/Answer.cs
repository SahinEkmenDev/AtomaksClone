using System.ComponentModel.DataAnnotations;

namespace AtomaksClone.Models
{
    public class Answer
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Text { get; set; } = string.Empty;

        public int QuestionId { get; set; }
        public string IconUrl { get; set; } = string.Empty;


        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;

        public Question Question { get; set; } = null!;
        public ICollection<AnswerImpact> AnswerImpacts { get; set; } = new List<AnswerImpact>();
    }
}
