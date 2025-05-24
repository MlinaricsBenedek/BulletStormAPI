using BulletStormAPI.Dto;
using BulletStormAPI.Model;

namespace BulletStormAPI.Services
{
    public interface IStatisticsService
    {
        Task<MatchesDto> GetAsync(int userId);

        Task<Statistics> GetStatsAsync(int userId);

        Task<float> GetELOAsync();

        Task<Statistics> CreateAsync(int userId);

        Task UpdateAsync(ResulClientDto resulClientDto, float elo);

        Task UpdateEloAsync(Statistics statistics);
    }
}