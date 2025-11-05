using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChoOnlineAPI.Services
{
    public class UserService : IUserRepository
    {
        private readonly AppDbContext _ctx;
        public UserService(AppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _ctx.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int userId)
        {
            return await _ctx.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserID == userId);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _ctx.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> CreateAsync(User user)
        {
            user.DateCreated = DateTime.UtcNow;
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _ctx.Entry(user).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int userId)
        {
            var entity = await _ctx.Users.FindAsync(userId);
            if (entity == null) return false;
            _ctx.Users.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetByRoleAsync(string role)
        {
            return await _ctx.Users.AsNoTracking().Where(u => u.Role == role).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByStatusAsync(string status)
        {
            return await _ctx.Users.AsNoTracking().Where(u => u.Status == status).ToListAsync();
        }
    }
}


