using ChoOnlineAPI.Models;

namespace ChoOnlineAPI.Repositories
{
    public interface IModerationLogRepository
    {
        Task<IEnumerable<ModerationLog>> GetAllAsync();
        Task<ModerationLog?> GetByIdAsync(int logId);
        Task<IEnumerable<ModerationLog>> GetByAdminIdAsync(int adminId);
        Task<ModerationLog> CreateAsync(ModerationLog log);
    }
}

