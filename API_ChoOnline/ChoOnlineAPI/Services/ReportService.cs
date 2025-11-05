using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChoOnlineAPI.Services
{
    public class ReportService : IReportRepository
    {
        private readonly AppDbContext _ctx;
        public ReportService(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Report>> GetAllAsync()
        {
            return await _ctx.Reports.AsNoTracking().ToListAsync();
        }

        public async Task<Report?> GetByIdAsync(int reportId)
        {
            return await _ctx.Reports.AsNoTracking().FirstOrDefaultAsync(r => r.ReportID == reportId);
        }

        public async Task<IEnumerable<Report>> GetPendingAsync()
        {
            return await _ctx.Reports.AsNoTracking().Where(r => r.Status == "Pending").ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetByStatusAsync(string status)
        {
            return await _ctx.Reports.AsNoTracking().Where(r => r.Status == status).ToListAsync();
        }

        public async Task<Report> CreateAsync(Report report)
        {
            report.CreatedAt = DateTime.UtcNow;
            _ctx.Reports.Add(report);
            await _ctx.SaveChangesAsync();
            return report;
        }

        public async Task<Report> UpdateAsync(Report report)
        {
            _ctx.Entry(report).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return report;
        }

        public async Task<bool> DeleteAsync(int reportId)
        {
            var entity = await _ctx.Reports.FindAsync(reportId);
            if (entity == null) return false;
            _ctx.Reports.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}


