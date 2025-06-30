using System.ComponentModel.DataAnnotations;

namespace AtomaksClone.Models
{
    public class Product
    {

        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string Desc { get; set; } = string.Empty;

        [StringLength(50)]
        public string Color { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Detail { get; set; } = string.Empty;

        [StringLength(300)]
        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<AnswerImpact> AnswerImpacts { get; set; } = new List<AnswerImpact>();
    }
}
