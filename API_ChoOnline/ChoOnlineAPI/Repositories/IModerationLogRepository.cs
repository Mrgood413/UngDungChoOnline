using ChoOnlineAPI.Models;

namespace ChoOnlineAPI.Repositories
{
    public interface IModerationLogRepository
    {
        Task<IEnumerable<AdminAction>> GetAllAsync();
        Task<AdminAction?> GetByIdAsync(int actionId);
        Task<IEnumerable<AdminAction>> GetByAdminIdAsync(int adminId);
        Task<IEnumerable<AdminAction>> GetByTargetUserIdAsync(int targetUserId);
        Task<AdminAction> CreateAsync(AdminAction action);
    }
}




