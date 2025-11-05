namespace ChoOnlineAPI.Models
{
    public class Report
    {
        public int ReportID { get; set; }
        public int ReporterID { get; set; }
        public int TargetProductID { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime ReportDate { get; set; }
    }
}

