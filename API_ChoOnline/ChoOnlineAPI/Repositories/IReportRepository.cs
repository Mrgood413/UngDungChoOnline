using ChoOnlineAPI.Models;

namespace ChoOnlineAPI.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetAllAsync();
        Task<Report?> GetByIdAsync(int reportId);
        Task<IEnumerable<Report>> GetPendingAsync();
        Task<IEnumerable<Report>> GetByStatusAsync(ReportStatus status);
        Task<Report> CreateAsync(Report report);
        Task<Report> UpdateAsync(Report report);
        Task<bool> DeleteAsync(int reportId);
    }
}
