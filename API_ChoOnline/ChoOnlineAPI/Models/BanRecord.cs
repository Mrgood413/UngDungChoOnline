namespace ChoOnlineAPI.Models
{
    public class BanRecord
    {
        public int BanId { get; set; }
        public int UserId { get; set; } // User bị cấm
        public int? ReportId { get; set; } // Report liên quan (nullable)
        public BanType BanType { get; set; }
        public string Reason { get; set; } = string.Empty;
        public int BannedBy { get; set; } // Admin thực hiện cấm
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } // NULL = vĩnh viễn
        public bool IsActive { get; set; } = true;
        public string? Notes { get; set; } // Ghi chú của admin
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
        public Report? Report { get; set; }
        public User Admin { get; set; } = null!; // Admin thực hiện
    }
}


