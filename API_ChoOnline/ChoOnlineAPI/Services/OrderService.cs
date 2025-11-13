using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChoOnlineAPI.Services
{
    public class OrderService : IOrderRepository
    {
        private readonly AppDbContext _ctx;
        public OrderService(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _ctx.Transactions.AsNoTracking().ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(int transactionId)
        {
            return await _ctx.Transactions.AsNoTracking().FirstOrDefaultAsync(t => t.TransactionId == transactionId);
        }

        public async Task<IEnumerable<Transaction>> GetByBuyerIdAsync(int buyerId)
        {
            return await _ctx.Transactions.AsNoTracking().Where(t => t.BuyerId == buyerId).ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetBySellerIdAsync(int sellerId)
        {
            return await _ctx.Transactions.AsNoTracking().Where(t => t.SellerId == sellerId).ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetByProductIdAsync(int productId)
        {
            return await _ctx.Transactions.AsNoTracking().Where(t => t.ProductId == productId).ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetByStatusAsync(TransactionStatus status)
        {
            return await _ctx.Transactions.AsNoTracking().Where(t => t.Status == status).ToListAsync();
        }

        public async Task<Transaction> CreateAsync(Transaction transaction)
        {
            transaction.CreatedAt = DateTime.UtcNow;
            _ctx.Transactions.Add(transaction);
            await _ctx.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> UpdateAsync(Transaction transaction)
        {
            _ctx.Entry(transaction).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return transaction;
        }

        public async Task<bool> DeleteAsync(int transactionId)
        {
            var entity = await _ctx.Transactions.FindAsync(transactionId);
            if (entity == null) return false;
            _ctx.Transactions.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}





