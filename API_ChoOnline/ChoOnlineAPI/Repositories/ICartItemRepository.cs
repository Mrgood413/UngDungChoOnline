using ChoOnlineAPI.Models;

namespace ChoOnlineAPI.Repositories
{
    public interface ICartItemRepository
    {
        Task<IEnumerable<CartItem>> GetByCartIdAsync(int cartId);
        Task<CartItem?> GetByCartAndProductIdAsync(int cartId, int productId);
        Task<CartItem> CreateAsync(CartItem cartItem);
        Task<CartItem> UpdateAsync(CartItem cartItem);
        Task<bool> DeleteAsync(int cartItemId);
        Task<bool> DeleteByCartAndProductIdAsync(int cartId, int productId);
        Task<bool> DeleteByCartIdAsync(int cartId);
    }
}
