using ChoOnlineAPI.Models;

namespace ChoOnlineAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetByBuyerIdAsync(int buyerId);
        Task<IEnumerable<Order>> GetBySellerIdAsync(int sellerId);
        Task<Order> CreateAsync(Order order);
        Task<Order> UpdateAsync(Order order);
        Task<bool> DeleteAsync(int orderId);
    }
}

