using BulletStormAPI.Model;

namespace BulletStormAPI.Repository
{
    public interface IGlobalStatisticsRepository
    {
        Task CreateAsync(Global global);
        
        Task<Global> GetAsync(int id);
        
        Task UpdateAsync(Global global);
    }
}