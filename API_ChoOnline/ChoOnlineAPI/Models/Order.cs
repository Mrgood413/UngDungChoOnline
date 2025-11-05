namespace ChoOnlineAPI.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int BuyerID { get; set; }
        public int SellerID { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; } = string.Empty;
    }
}

