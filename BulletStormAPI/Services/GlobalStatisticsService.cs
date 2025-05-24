using BulletStormAPI.Model;
using BulletStormAPI.Repository;

namespace BulletStormAPI.Services
{
    public class GlobalStatisticsService : IGlobalStatisticsService
    {
        private readonly IGlobalStatisticsRepository _globalRepository;

        public GlobalStatisticsService(IGlobalStatisticsRepository globalStatistics)
        {
            _globalRepository = globalStatistics;
        }

        public Task<Global> GetAsync(int id)
        {
            return _globalRepository.GetAsync(id);
        }

        public async Task CreateAsync(Global global)
        {
            await _globalRepository.CreateAsync(global);
        }

        public async Task UpdateAsync(Global global)
        {
            await _globalRepository.UpdateAsync(global);
        }

    }
}
