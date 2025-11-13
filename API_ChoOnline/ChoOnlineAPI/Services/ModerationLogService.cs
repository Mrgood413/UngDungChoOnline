using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChoOnlineAPI.Services
{
    public class ModerationLogService : IModerationLogRepository
    {
        private readonly AppDbContext _ctx;
        public ModerationLogService(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<AdminAction>> GetAllAsync()
        {
            return await _ctx.AdminActions.AsNoTracking().ToListAsync();
        }

        public async Task<AdminAction?> GetByIdAsync(int actionId)
        {
            return await _ctx.AdminActions.AsNoTracking().FirstOrDefaultAsync(a => a.ActionId == actionId);
        }

        public async Task<IEnumerable<AdminAction>> GetByAdminIdAsync(int adminId)
        {
            return await _ctx.AdminActions.AsNoTracking().Where(a => a.AdminId == adminId).ToListAsync();
        }

        public async Task<IEnumerable<AdminAction>> GetByTargetUserIdAsync(int targetUserId)
        {
            return await _ctx.AdminActions.AsNoTracking().Where(a => a.TargetUserId == targetUserId).ToListAsync();
        }

        public async Task<AdminAction> CreateAsync(AdminAction action)
        {
            action.CreatedAt = DateTime.UtcNow;
            _ctx.AdminActions.Add(action);
            await _ctx.SaveChangesAsync();
            return action;
        }
    }
}





