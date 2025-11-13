namespace ChoOnlineAPI.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int ReviewerId { get; set; } // Người đánh giá
        public int RevieweeId { get; set; } // Người được đánh giá
        public int TransactionId { get; set; }
        public int Rating { get; set; } // 1-5 sao
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public User Reviewer { get; set; } = null!;
        public User Reviewee { get; set; } = null!;
        public Transaction Transaction { get; set; } = null!;
    }
}
