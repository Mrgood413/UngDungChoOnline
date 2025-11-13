namespace ChoOnlineAPI.Models
{
    public class ProductImage
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPrimary { get; set; } = false;
        public int OrderIndex { get; set; } = 0;

        // Navigation property
        public Product Product { get; set; } = null!;
    }
}
