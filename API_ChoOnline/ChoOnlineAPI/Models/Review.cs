namespace ChoOnlineAPI.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int BuyerID { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}

