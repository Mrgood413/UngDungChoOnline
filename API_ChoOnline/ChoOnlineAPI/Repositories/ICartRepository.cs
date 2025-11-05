using ChoOnlineAPI.Models;

namespace ChoOnlineAPI.Repositories
{
    public interface ICartRepository
    {
        Task<Cart?> GetByBuyerIdAsync(int buyerId);
        Task<Cart> CreateAsync(Cart cart);
        Task<bool> ClearCartAsync(int buyerId);
    }
}

