using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChoOnlineAPI.Services
{
    public class ReviewService : IReviewRepository
    {
        private readonly AppDbContext _ctx;
        public ReviewService(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _ctx.Reviews.AsNoTracking().ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int reviewId)
        {
            return await _ctx.Reviews.AsNoTracking().FirstOrDefaultAsync(r => r.ReviewId == reviewId);
        }

        public async Task<IEnumerable<Review>> GetByProductIdAsync(int productId)
        {
            return await _ctx.Reviews.AsNoTracking()
                .Include(r => r.Transaction)
                .Where(r => r.Transaction.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetByRevieweeIdAsync(int userId)
        {
            return await _ctx.Reviews.AsNoTracking().Where(r => r.RevieweeId == userId).ToListAsync();
        }

        public async Task<Review> CreateAsync(Review review)
        {
            _ctx.Reviews.Add(review);
            await _ctx.SaveChangesAsync();
            return review;
        }

        public async Task<bool> DeleteAsync(int reviewId)
        {
            var entity = await _ctx.Reviews.FindAsync(reviewId);
            if (entity == null) return false;
            _ctx.Reviews.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}



