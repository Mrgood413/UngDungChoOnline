using ChoOnlineAPI.Models;

namespace ChoOnlineAPI.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int userId);
        Task<User?> GetByEmailAsync(string email);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(int userId);
        Task<IEnumerable<User>> GetByRoleAsync(UserRole role);
    }
}

