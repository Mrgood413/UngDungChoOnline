using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChoOnlineAPI.Services
{
    public class ModerationLogService : IModerationLogRepository
    {
        private readonly AppDbContext _ctx;
        public ModerationLogService(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<ModerationLog>> GetAllAsync()
        {
            return await _ctx.ModerationLogs.AsNoTracking().ToListAsync();
        }

        public async Task<ModerationLog?> GetByIdAsync(int logId)
        {
            return await _ctx.ModerationLogs.AsNoTracking().FirstOrDefaultAsync(l => l.LogID == logId);
        }

        public async Task<IEnumerable<ModerationLog>> GetByAdminIdAsync(int adminId)
        {
            return await _ctx.ModerationLogs.AsNoTracking().Where(l => l.AdminID == adminId).ToListAsync();
        }

        public async Task<ModerationLog> CreateAsync(ModerationLog log)
        {
            log.CreatedAt = DateTime.UtcNow;
            _ctx.ModerationLogs.Add(log);
            await _ctx.SaveChangesAsync();
            return log;
        }
    }
}


