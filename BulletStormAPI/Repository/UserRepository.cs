using BulletStormAPI.DatabaseConnection;
using BulletStormAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BulletStormAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnect _dbConnect;

        public UserRepository(DbConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _dbConnect.Users.AddAsync(user);
            await _dbConnect.SaveChangesAsync();
            return user;
        }

        public Task<User?> GetAsync(int id)
        {
            return _dbConnect.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<User?> GetByNameAsync(string name)
        {
            return _dbConnect.Users.FirstOrDefaultAsync(u => u.Name == name);
        }

        public Task<User?> GetByIdAsync(int id)
        {
            return _dbConnect.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
