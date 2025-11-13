namespace ChoOnlineAPI.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public TransactionStatus Status { get; set; }
        public string? MeetingLocation { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        // Navigation properties
        public Product Product { get; set; } = null!;
        public User Buyer { get; set; } = null!;
        public User Seller { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
