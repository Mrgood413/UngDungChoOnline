using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChoOnlineAPI.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly AppDbContext _ctx;
        public CategoryService(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _ctx.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int categoryId)
        {
            return await _ctx.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _ctx.Categories.Add(category);
            await _ctx.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _ctx.Entry(category).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(int categoryId)
        {
            var entity = await _ctx.Categories.FindAsync(categoryId);
            if (entity == null) return false;
            _ctx.Categories.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}



