using BulletStormAPI.DatabaseConnection;
using BulletStormAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BulletStormAPI.Repository
{
    public class GlobalStatisticsRepository : IGlobalStatisticsRepository
    {
        private readonly DbConnect _dbConnect;

        public GlobalStatisticsRepository(DbConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public async Task CreateAsync(Global global)
        {
            await _dbConnect.Globals.AddAsync(global);
            await _dbConnect.SaveChangesAsync();
        }

        public async Task UpdateAsync(Global global)
        {
            _dbConnect.Globals.Update(global);
            await _dbConnect.SaveChangesAsync();
        }

        public Task<Global> GetAsync(int id)
        {
            return _dbConnect.Globals.FirstAsync(x => x.Id == id);
        }
    }
}
