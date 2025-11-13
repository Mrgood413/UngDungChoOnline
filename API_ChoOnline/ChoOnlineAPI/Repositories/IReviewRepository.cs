using ChoOnlineAPI.Models;

namespace ChoOnlineAPI.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllAsync();
        Task<Review?> GetByIdAsync(int reviewId);
        Task<IEnumerable<Review>> GetByProductIdAsync(int productId);
        Task<IEnumerable<Review>> GetByRevieweeIdAsync(int userId);
        Task<Review> CreateAsync(Review review);
        Task<bool> DeleteAsync(int reviewId);
    }
}


