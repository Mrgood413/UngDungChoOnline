namespace ChoOnlineAPI.Models
{
    public class ModerationLog
    {
        public int LogID { get; set; }
        public int AdminID { get; set; }
        public string Action { get; set; } = string.Empty;
        public int TargetID { get; set; }
        public string? Description { get; set; }
        public DateTime DateAction { get; set; }
    }
}

