namespace ChoOnlineAPI.Models
{
    public class TrustHistory
    {
        public int HistoryId { get; set; }
        public int UserId { get; set; }
        public int ChangeAmount { get; set; } // +/- điểm
        public TrustHistoryReason Reason { get; set; }
        public int? RelatedId { get; set; } // FK đến review hoặc report
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public User User { get; set; } = null!;
    }
}
