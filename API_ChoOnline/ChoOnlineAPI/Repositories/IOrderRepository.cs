using ChoOnlineAPI.Models;

namespace ChoOnlineAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(int transactionId);
        Task<IEnumerable<Transaction>> GetByBuyerIdAsync(int buyerId);
        Task<IEnumerable<Transaction>> GetBySellerIdAsync(int sellerId);
        Task<IEnumerable<Transaction>> GetByProductIdAsync(int productId);
        Task<IEnumerable<Transaction>> GetByStatusAsync(TransactionStatus status);
        Task<Transaction> CreateAsync(Transaction transaction);
        Task<Transaction> UpdateAsync(Transaction transaction);
        Task<bool> DeleteAsync(int transactionId);
    }
}




