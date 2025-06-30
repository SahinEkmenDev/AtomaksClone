using System.ComponentModel.DataAnnotations;

namespace AtomaksClone.Models
{
    public class AnswerImpact
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int ProductId { get; set; }

        [Required]
        public int Point { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;

        public Answer Answer { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
