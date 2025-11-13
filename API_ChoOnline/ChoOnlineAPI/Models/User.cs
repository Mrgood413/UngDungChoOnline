namespace ChoOnlineAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }
        public UserRole Role { get; set; }
        public int TrustScore { get; set; } = 50; // Default trust score (0-100)
        public AccountStatus AccountStatus { get; set; } = AccountStatus.Active;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Review> ReviewsGiven { get; set; } = new List<Review>();
        public ICollection<Review> ReviewsReceived { get; set; } = new List<Review>();
        public ICollection<Report> ReportsMade { get; set; } = new List<Report>();
        public ICollection<Report> ReportsReceived { get; set; } = new List<Report>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Transaction> TransactionsAsBuyer { get; set; } = new List<Transaction>();
        public ICollection<Transaction> TransactionsAsSeller { get; set; } = new List<Transaction>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
        public ICollection<Conversation> ConversationsAsBuyer { get; set; } = new List<Conversation>();
        public ICollection<Conversation> ConversationsAsSeller { get; set; } = new List<Conversation>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<TrustHistory> TrustHistories { get; set; } = new List<TrustHistory>();
        public ICollection<AdminAction> AdminActionsPerformed { get; set; } = new List<AdminAction>();
        public ICollection<AdminAction> AdminActionsReceived { get; set; } = new List<AdminAction>();
        public ICollection<BanRecord> BanRecords { get; set; } = new List<BanRecord>();
        public ICollection<BanRecord> BansIssued { get; set; } = new List<BanRecord>();
    }
}
