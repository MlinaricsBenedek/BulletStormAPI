using AutoMapper;
using BulletStormAPI.Dto;
using BulletStormAPI.Model;
using BulletStormAPI.Repository;

namespace BulletStormAPI.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _statisticsRepository;
        private readonly IMapper _mapper;
        private readonly IUserInformation _userInformation;
       
        public StatisticsService(IStatisticsRepository statisticsRepository, IMapper mapper, IUserInformation userInformation)
        {
            _statisticsRepository = statisticsRepository;
            _mapper = mapper;
            _userInformation = userInformation;
        }

        public async Task<MatchesDto> GetAsync(int userId)
        {
            var matches = await _statisticsRepository.GetAsync(userId);//nem létezik még jelenlegi user statisztika. 
            var matchesDto = _mapper.Map<MatchesDto>(matches);
            return matchesDto;
        }

        public async Task<Statistics> GetStatsAsync(int userId)
        {
           return await _statisticsRepository.GetAsync(userId);
        }

        public async Task<float> GetELOAsync()
        {
            var matches = await _statisticsRepository.GetAsync(_userInformation.UserId);
            
            return matches.ELO;
        }


        public async Task<Statistics> CreateAsync(int userId)
        {
            Statistics statistics = new()
            {
                AggregatedAssits = 0,
                AggregatedKills = 0,
                AggregatedMatches = 0,
                AggregatedDeath = 0,
                ELO = 800,
                UserId = userId,

            };
            return await _statisticsRepository.CreateAsync(statistics);
        }



        public async Task UpdateAsync(ResulClientDto resulClientDto,float elo)
        {
            var oldData = await _statisticsRepository.GetAsync(_userInformation.UserId);
            oldData.ELO = elo;
            await _statisticsRepository.UpdateAsync(CalculateNewStatistics(oldData, resulClientDto));
        }

        public async Task UpdateEloAsync(Statistics statistics)
        {
            await _statisticsRepository.UpdateAsync(statistics);
        }

        private Statistics CalculateNewStatistics(Statistics oldData, ResulClientDto resulClientDto)
        {
            int id = oldData.Id;
            
            oldData.Id = id;
            oldData.AggregatedDeath += resulClientDto.Deaths;
            oldData.AggregatedAssits += resulClientDto.Assist;
            oldData.AggregatedKills += resulClientDto.Kill;
            oldData.AggregatedMatches += 1;
            oldData.Updated = DateTime.Now;
            return oldData;
        }
    }
}
