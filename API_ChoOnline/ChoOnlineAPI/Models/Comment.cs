namespace ChoOnlineAPI.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = string.Empty;
        public int? ParentCommentId { get; set; } // Cho reply
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public Product Product { get; set; } = null!;
        public User User { get; set; } = null!;
        public Comment? ParentComment { get; set; }
        public ICollection<Comment> Replies { get; set; } = new List<Comment>();
    }
}
