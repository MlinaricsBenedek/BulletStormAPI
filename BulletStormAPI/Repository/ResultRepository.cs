using BulletStormAPI.DatabaseConnection;
using BulletStormAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BulletStormAPI.Repository
{
    public class ResultRepository : IResultRepository
    {
        private readonly DbConnect _dbConnect;

        public ResultRepository(DbConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public async Task<Result?> CreateAsync(Result result)
        {
            await _dbConnect.Results.AddAsync(result);
            await _dbConnect.SaveChangesAsync();
            return result;
        }

        public Task<List<Result?>> GetAsync(int userId)
        {
            return _dbConnect.Results.AsNoTracking().Include(r=>r.User).Where(r => r.User.Id == userId).ToListAsync();
        }

        public async Task<int> GetCountAsync(int userId)
        {
            bool exist = await _dbConnect.Results.AnyAsync(r=>r.User.Id == userId);
            if (!exist)
            { 
                return 0;
            }
            return await _dbConnect.Results.AsNoTracking().CountAsync(r=>r.User.Id == userId);
        }

        public async Task UpdateAsync(Result result)
        {
            _dbConnect.Results.Update(result);
            await _dbConnect.SaveChangesAsync();
        }
    }
}
