using ChoOnlineAPI.Models;

namespace ChoOnlineAPI.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllAsync();
        Task<Review?> GetByIdAsync(int reviewId);
        Task<IEnumerable<Review>> GetByProductIdAsync(int productId);
        Task<IEnumerable<Review>> GetByBuyerIdAsync(int buyerId);
        Task<Review> CreateAsync(Review review);
        Task<bool> DeleteAsync(int reviewId);
    }
}

