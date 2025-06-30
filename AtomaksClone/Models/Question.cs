using System.ComponentModel.DataAnnotations;

namespace AtomaksClone.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required, StringLength(500)]
        public string Text { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;

        public string IconUrl { get; set; } = string.Empty;

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
