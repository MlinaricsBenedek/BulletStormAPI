using AutoMapper;
using BulletStormAPI.Dto;
using BulletStormAPI.Model;
using BulletStormAPI.Repository;

namespace BulletStormAPI.Services
{
    public class MatchService : IMatchService
    {

        private readonly IMapper _mapper;
        private readonly IResultService _resultService;
        private readonly IUserService _userService;
        private readonly IUserInformation _userInformation;
        private readonly IGlobalStatisticsService _globalStatisticsService;
        private readonly IStatisticsService _statisticsService;

        public MatchService( IMapper mapper, IResultService resultService, IUserService userService, IUserInformation userInformation, IGlobalStatisticsService globalStatisticsService,IStatisticsService statisticsService)
        {
            _mapper = mapper;
            _resultService = resultService;
            _userService = userService;
            _userInformation = userInformation;
            _globalStatisticsService = globalStatisticsService;
           _statisticsService = statisticsService;
        }

        public async Task UpdateAsync(MatchResultClientDto matchResultDto)
        {
            var results = await _resultService.GetAsync(); 
            var oldestMatch = results.OrderBy(x => x.UpdatedAt).FirstOrDefault();
            

            float elo =await GetELO(matchResultDto,results);
            oldestMatch.UpdatedAt = DateTime.Now;
            await _resultService.UpdateAsync(oldestMatch);
            await _statisticsService.UpdateAsync(matchResultDto.ResulClient,elo);
        }

        public async Task CreateAsync(MatchResultClientDto matchResultDto)
        {
            var user =await _userService.GetById(_userInformation.UserId);
            int matchCounter = await _resultService.MatchCountAsync();
          
            await _resultService.CreateAsync(matchResultDto, user);
         
        }

        public async Task<float> GetELO(MatchResultClientDto matchResultClientDto,List<Result> results)
        {
            var globalStatistics = await _globalStatisticsService.GetAsync(1);
            var statistics = await _statisticsService.GetAsync(_userInformation.UserId);
            float elo = EloHandler.CalculateELo(matchResultClientDto, results, globalStatistics,statistics);
            return elo;
        }
}
}
