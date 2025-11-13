namespace ChoOnlineAPI.Models
{
    public class Conversation
    {
        public int ConversationId { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public int ProductId { get; set; }
        public DateTime? LastMessageAt { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public User Buyer { get; set; } = null!;
        public User Seller { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
