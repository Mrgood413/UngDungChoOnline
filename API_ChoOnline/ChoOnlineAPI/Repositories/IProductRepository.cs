using ChoOnlineAPI.Models;

namespace ChoOnlineAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int productId);
        Task<IEnumerable<Product>> GetBySellerIdAsync(int sellerId);
        Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int productId);
        Task<IEnumerable<Product>> SearchAsync(string? keyword, int? categoryId, decimal? minPrice, decimal? maxPrice, string? location);
    }
}




