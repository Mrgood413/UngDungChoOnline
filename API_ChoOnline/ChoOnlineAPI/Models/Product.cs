namespace ChoOnlineAPI.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int SellerID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? ImageURL { get; set; }
        public string? Location { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
    }
}

