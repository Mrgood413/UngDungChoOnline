namespace ChoOnlineAPI.Models
{
    public class RegisterRequest
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class ProductCreateRequest
    {
        public int SellerID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? ImageURL { get; set; }
        public string? Location { get; set; }
    }

    public class ProductUpdateRequest
    {
        public int CategoryID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? ImageURL { get; set; }
        public string? Location { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class CategoryRequest
    {
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class CartItemRequest
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderCreateRequest
    {
        public int BuyerID { get; set; }
        public int SellerID { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
    }

    public class OrderStatusUpdateRequest
    {
        public string Status { get; set; } = string.Empty;
    }

    public class ReviewCreateRequest
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int BuyerID { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }

    public class ReportCreateRequest
    {
        public int ReporterID { get; set; }
        public int TargetProductID { get; set; }
        public string Reason { get; set; } = string.Empty;
    }

    public class ReportStatusUpdateRequest
    {
        public string Status { get; set; } = string.Empty;
    }
}



