namespace AtomaksClone.DTOs
{
    public class AnswerImpactDto
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int ProductId { get; set; }
        public int Point { get; set; }
        

    }

    public class CreateAnswerImpactDto
    {
        public int AnswerId { get; set; }
        public int ProductId { get; set; }
        public int Point { get; set; }
       
    }

    public class UpdateAnswerImpactDto
    {
        public int Point { get; set; }
        

    }
}
