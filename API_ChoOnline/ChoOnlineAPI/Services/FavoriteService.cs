using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChoOnlineAPI.Services
{
    public class FavoriteService : IFavoriteRepository
    {
        private readonly AppDbContext _ctx;
        public FavoriteService(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Favorite>> GetAllAsync()
        {
            return await _ctx.Favorites.AsNoTracking().ToListAsync();
        }

        public async Task<Favorite?> GetByIdAsync(int favoriteId)
        {
            return await _ctx.Favorites.AsNoTracking().FirstOrDefaultAsync(f => f.FavoriteId == favoriteId);
        }

        public async Task<IEnumerable<Favorite>> GetByUserIdAsync(int userId)
        {
            return await _ctx.Favorites
                .AsNoTracking()
                .Include(f => f.Product)
                    .ThenInclude(p => p.Images)
                .Where(f => f.UserId == userId)
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Favorite>> GetByProductIdAsync(int productId)
        {
            return await _ctx.Favorites.AsNoTracking().Where(f => f.ProductId == productId).ToListAsync();
        }

        public async Task<Favorite?> GetByUserAndProductIdAsync(int userId, int productId)
        {
            return await _ctx.Favorites
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.UserId == userId && f.ProductId == productId);
        }

        public async Task<bool> ExistsAsync(int userId, int productId)
        {
            return await _ctx.Favorites
                .AnyAsync(f => f.UserId == userId && f.ProductId == productId);
        }

        public async Task<Favorite> CreateAsync(Favorite favorite)
        {
            favorite.CreatedAt = DateTime.UtcNow;
            _ctx.Favorites.Add(favorite);
            await _ctx.SaveChangesAsync();
            return favorite;
        }

        public async Task<bool> DeleteAsync(int favoriteId)
        {
            var entity = await _ctx.Favorites.FindAsync(favoriteId);
            if (entity == null) return false;
            _ctx.Favorites.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByUserAndProductIdAsync(int userId, int productId)
        {
            var entity = await _ctx.Favorites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.ProductId == productId);
            if (entity == null) return false;
            _ctx.Favorites.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}

