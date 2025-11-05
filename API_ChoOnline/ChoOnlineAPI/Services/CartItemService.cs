using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChoOnlineAPI.Services
{
    public class CartItemService : ICartItemRepository
    {
        private readonly AppDbContext _ctx;
        public CartItemService(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<CartItem>> GetByCartIdAsync(int cartId)
        {
            return await _ctx.CartItems.AsNoTracking().Where(ci => ci.CartID == cartId).ToListAsync();
        }

        public async Task<CartItem?> GetByCartAndProductIdAsync(int cartId, int productId)
        {
            return await _ctx.CartItems.AsNoTracking().FirstOrDefaultAsync(ci => ci.CartID == cartId && ci.ProductID == productId);
        }

        public async Task<CartItem> CreateAsync(CartItem cartItem)
        {
            _ctx.CartItems.Add(cartItem);
            await _ctx.SaveChangesAsync();
            return cartItem;
        }

        public async Task<CartItem> UpdateAsync(CartItem cartItem)
        {
            _ctx.Entry(cartItem).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return cartItem;
        }

        public async Task<bool> DeleteAsync(int cartItemId)
        {
            var entity = await _ctx.CartItems.FindAsync(cartItemId);
            if (entity == null) return false;
            _ctx.CartItems.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByCartAndProductIdAsync(int cartId, int productId)
        {
            var entity = await _ctx.CartItems.FirstOrDefaultAsync(ci => ci.CartID == cartId && ci.ProductID == productId);
            if (entity == null) return false;
            _ctx.CartItems.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByCartIdAsync(int cartId)
        {
            var entities = _ctx.CartItems.Where(ci => ci.CartID == cartId);
            _ctx.CartItems.RemoveRange(entities);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}


