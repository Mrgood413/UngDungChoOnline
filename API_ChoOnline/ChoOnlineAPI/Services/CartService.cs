using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChoOnlineAPI.Services
{
    public class CartService : ICartRepository
    {
        private readonly AppDbContext _ctx;
        public CartService(AppDbContext ctx) => _ctx = ctx;

        public async Task<Cart?> GetByBuyerIdAsync(int buyerId)
        {
            return await _ctx.Carts.AsNoTracking().FirstOrDefaultAsync(c => c.BuyerID == buyerId);
        }

        public async Task<Cart> CreateAsync(Cart cart)
        {
            _ctx.Carts.Add(cart);
            await _ctx.SaveChangesAsync();
            return cart;
        }

        public async Task<bool> ClearCartAsync(int buyerId)
        {
            var cart = await _ctx.Carts.FirstOrDefaultAsync(c => c.BuyerID == buyerId);
            if (cart == null) return false;
            var items = _ctx.CartItems.Where(i => i.CartID == cart.CartID);
            _ctx.CartItems.RemoveRange(items);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}


