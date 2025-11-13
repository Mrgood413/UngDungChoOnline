namespace ChoOnlineAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ProductCondition Condition { get; set; }
        public ProductStatus Status { get; set; }
        public double? LocationLat { get; set; }
        public double? LocationLng { get; set; }
        public string? AddressText { get; set; }
        public int ViewCount { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public User Seller { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<Conversation> Conversations { get; set; } = new List<Conversation>();
    }
}
