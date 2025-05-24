using BulletStormAPI.Model;

namespace BulletStormAPI.Services
{
    public interface IGlobalStatisticsService
    {
        Task CreateAsync(Global global);

        Task<Global> GetAsync(int id);

        Task UpdateAsync(Global global);
    }
}