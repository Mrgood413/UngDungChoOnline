using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChoOnlineAPI.Services
{
    public class ProductService : IProductRepository
    {
        private readonly AppDbContext _ctx;
        public ProductService(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _ctx.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await _ctx.Products.AsNoTracking().FirstOrDefaultAsync(p => p.ProductID == productId);
        }

        public async Task<IEnumerable<Product>> GetBySellerIdAsync(int sellerId)
        {
            return await _ctx.Products.AsNoTracking().Where(p => p.SellerID == sellerId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
        {
            return await _ctx.Products.AsNoTracking().Where(p => p.CategoryID == categoryId).ToListAsync();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _ctx.Products.Add(product);
            await _ctx.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _ctx.Entry(product).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(int productId)
        {
            var entity = await _ctx.Products.FindAsync(productId);
            if (entity == null) return false;
            _ctx.Products.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> SearchAsync(string? keyword, int? categoryId, decimal? minPrice, decimal? maxPrice, string? location)
        {
            var q = _ctx.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                q = q.Where(p => p.ProductName.Contains(keyword) || (p.Description != null && p.Description.Contains(keyword)));
            }
            if (categoryId.HasValue) q = q.Where(p => p.CategoryID == categoryId);
            if (minPrice.HasValue) q = q.Where(p => p.Price >= minPrice);
            if (maxPrice.HasValue) q = q.Where(p => p.Price <= maxPrice);
            if (!string.IsNullOrWhiteSpace(location)) q = q.Where(p => p.Location == location);
            return await q.AsNoTracking().OrderByDescending(p => p.DateCreated).ToListAsync();
        }
    }
}


