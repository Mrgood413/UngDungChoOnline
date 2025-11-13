namespace ChoOnlineAPI.Models
{
    public class AdminAction
    {
        public int ActionId { get; set; }
        public int AdminId { get; set; }
        public int TargetUserId { get; set; }
        public AdminActionType ActionType { get; set; }
        public string Reason { get; set; } = string.Empty;
        public int? DurationDays { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public User Admin { get; set; } = null!;
        public User TargetUser { get; set; } = null!;
    }
}
