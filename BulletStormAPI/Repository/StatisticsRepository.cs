using BulletStormAPI.DatabaseConnection;
using BulletStormAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BulletStormAPI.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly DbConnect _dbConnect;

        public StatisticsRepository(DbConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public async Task<Statistics> CreateAsync(Statistics matches)
        {
            await _dbConnect.Matches.AddAsync(matches);
            await _dbConnect.SaveChangesAsync();
            return matches;
        }

        public async Task UpdateAsync(Statistics matches)
        {
            _dbConnect.Matches.Update(matches);
            await _dbConnect.SaveChangesAsync();
        }

        public Task<Statistics> GetAsync(int userId)
        {
            return _dbConnect.Matches.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
