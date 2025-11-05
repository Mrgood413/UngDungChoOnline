using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChoOnlineAPI.Services
{
    public class OrderDetailService : IOrderDetailRepository
    {
        private readonly AppDbContext _ctx;
        public OrderDetailService(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId)
        {
            return await _ctx.OrderDetails.AsNoTracking().Where(od => od.OrderID == orderId).ToListAsync();
        }

        public async Task<OrderDetail?> GetByIdAsync(int orderDetailId)
        {
            return await _ctx.OrderDetails.AsNoTracking().FirstOrDefaultAsync(od => od.OrderDetailID == orderDetailId);
        }

        public async Task<OrderDetail> CreateAsync(OrderDetail orderDetail)
        {
            _ctx.OrderDetails.Add(orderDetail);
            await _ctx.SaveChangesAsync();
            return orderDetail;
        }

        public async Task<IEnumerable<OrderDetail>> CreateRangeAsync(IEnumerable<OrderDetail> orderDetails)
        {
            _ctx.OrderDetails.AddRange(orderDetails);
            await _ctx.SaveChangesAsync();
            return orderDetails;
        }

        public async Task<OrderDetail> UpdateAsync(OrderDetail orderDetail)
        {
            _ctx.Entry(orderDetail).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return orderDetail;
        }

        public async Task<bool> DeleteAsync(int orderDetailId)
        {
            var entity = await _ctx.OrderDetails.FindAsync(orderDetailId);
            if (entity == null) return false;
            _ctx.OrderDetails.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}


