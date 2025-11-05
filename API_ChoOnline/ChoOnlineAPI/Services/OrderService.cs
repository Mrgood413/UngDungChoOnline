using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChoOnlineAPI.Services
{
    public class OrderService : IOrderRepository
    {
        private readonly AppDbContext _ctx;
        public OrderService(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _ctx.Orders.AsNoTracking().ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int orderId)
        {
            return await _ctx.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.OrderID == orderId);
        }

        public async Task<IEnumerable<Order>> GetByBuyerIdAsync(int buyerId)
        {
            return await _ctx.Orders.AsNoTracking().Where(o => o.BuyerID == buyerId).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetBySellerIdAsync(int sellerId)
        {
            return await _ctx.Orders.AsNoTracking().Where(o => o.SellerID == sellerId).ToListAsync();
        }

        public async Task<Order> CreateAsync(Order order)
        {
            _ctx.Orders.Add(order);
            await _ctx.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            _ctx.Entry(order).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteAsync(int orderId)
        {
            var entity = await _ctx.Orders.FindAsync(orderId);
            if (entity == null) return false;
            _ctx.Orders.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}


