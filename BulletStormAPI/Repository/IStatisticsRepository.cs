using BulletStormAPI.Model;

namespace BulletStormAPI.Repository
{
    public interface IStatisticsRepository
    {
        Task<Statistics> CreateAsync(Statistics matches);

        Task<Statistics> GetAsync(int userId);

        Task UpdateAsync(Statistics matches);
    }
}