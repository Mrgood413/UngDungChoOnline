namespace ChoOnlineAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public string? IconUrl { get; set; }
        public string? Description { get; set; }

        // Navigation properties
        public Category? Parent { get; set; }
        public ICollection<Category> Children { get; set; } = new List<Category>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
