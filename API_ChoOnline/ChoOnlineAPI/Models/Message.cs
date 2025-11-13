namespace ChoOnlineAPI.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int ConversationId { get; set; }
        public int SenderId { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public Conversation Conversation { get; set; } = null!;
        public User Sender { get; set; } = null!;
    }
}
