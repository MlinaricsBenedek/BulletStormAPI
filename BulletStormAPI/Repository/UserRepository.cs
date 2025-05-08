using BulletStormAPI.DatabaseConnection;
using BulletStormAPI.Dto;
using BulletStormAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BulletStormAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnect _dbConnect;

        public UserRepository(DbConnect dbConnect)
        {
           _dbConnect = dbConnect;
        }

        public async Task CreateAsync(User user)
        {
            await _dbConnect.Users.AddAsync(user);
            await _dbConnect.SaveChangesAsync();
        }

        public Task<User?> GetAsync(int id)
        {
            return _dbConnect.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<User?> GetByNameAsync(string name)
        {
            return _dbConnect.Users.FirstOrDefaultAsync(u => u.Name == name);
        }
    }
}
