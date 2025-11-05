using ChoOnlineAPI.Models;

namespace ChoOnlineAPI.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId);
        Task<OrderDetail?> GetByIdAsync(int orderDetailId);
        Task<OrderDetail> CreateAsync(OrderDetail orderDetail);
        Task<IEnumerable<OrderDetail>> CreateRangeAsync(IEnumerable<OrderDetail> orderDetails);
        Task<OrderDetail> UpdateAsync(OrderDetail orderDetail);
        Task<bool> DeleteAsync(int orderDetailId);
    }
}

