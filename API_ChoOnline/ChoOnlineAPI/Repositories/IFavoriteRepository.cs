using ChoOnlineAPI.Models;

namespace ChoOnlineAPI.Repositories
{
    public interface IFavoriteRepository
    {
        Task<IEnumerable<Favorite>> GetAllAsync();
        Task<Favorite?> GetByIdAsync(int favoriteId);
        Task<IEnumerable<Favorite>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Favorite>> GetByProductIdAsync(int productId);
        Task<Favorite?> GetByUserAndProductIdAsync(int userId, int productId);
        Task<bool> ExistsAsync(int userId, int productId);
        Task<Favorite> CreateAsync(Favorite favorite);
        Task<bool> DeleteAsync(int favoriteId);
        Task<bool> DeleteByUserAndProductIdAsync(int userId, int productId);
    }
}

