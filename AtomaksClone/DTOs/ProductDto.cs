namespace AtomaksClone.DTOs
{
    namespace AtomaksClone.DTOs
    {
        public class ProductDto
        {
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public string Desc { get; set; } = string.Empty;
            public string Color { get; set; } = string.Empty;
            public string Detail { get; set; } = string.Empty;
            public string ImageUrl { get; set; } = string.Empty;
        }

        public class CreateProductDto
        {
            public string Title { get; set; } = string.Empty;
            public string Desc { get; set; } = string.Empty;
            public string Color { get; set; } = string.Empty;
            public string Detail { get; set; } = string.Empty;
            
        }

        public class UpdateProductDto
        {
            public string Title { get; set; } = string.Empty;
            public string Desc { get; set; } = string.Empty;
            public string Color { get; set; } = string.Empty;
            public string Detail { get; set; } = string.Empty;
           
        }
    }

}
