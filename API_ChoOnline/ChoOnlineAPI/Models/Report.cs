namespace ChoOnlineAPI.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public int ReporterId { get; set; } // Người báo cáo
        public int? ReportedUserId { get; set; } // Người bị báo cáo (nullable)
        public int? ReportedProductId { get; set; } // Sản phẩm bị báo cáo (nullable)
        public int? ReportedCommentId { get; set; } // Comment bị báo cáo (nullable)
        public ReportType ReportType { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? EvidenceUrls { get; set; } // JSON - ảnh/video bằng chứng
        public ReportStatus Status { get; set; } = ReportStatus.Pending;
        public ReportPriority Priority { get; set; } = ReportPriority.Medium;
        public string? AdminNote { get; set; }
        public int? ResolvedBy { get; set; } // Admin xử lý
        public ResolutionAction? ResolutionAction { get; set; } // Hành động xử lý
        public DateTime CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }

        // Navigation properties
        public User Reporter { get; set; } = null!;
        public User? ReportedUser { get; set; }
        public Product? ReportedProduct { get; set; }
        public Comment? ReportedComment { get; set; }
        public User? Resolver { get; set; }
        public ICollection<BanRecord> BanRecords { get; set; } = new List<BanRecord>();
    }
}
