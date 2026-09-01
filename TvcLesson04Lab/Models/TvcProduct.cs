namespace TvcLesson04Lab.Models
{
    public class TvcProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public int ReleaseYear { get; set; }
        public string Platform { get; set; }
        public double Rating { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public bool IsHot { get; set; }  
        public bool IsNew { get; set; }  
    }
}