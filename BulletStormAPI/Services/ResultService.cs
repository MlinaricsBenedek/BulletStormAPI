using AutoMapper;
using BulletStormAPI.Dto;
using BulletStormAPI.Model;
using BulletStormAPI.Repository;

namespace BulletStormAPI.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        private readonly IMapper _mapper;
        private readonly IUserInformation _userInformation;

        public ResultService(IResultRepository result, IMapper mapper,IUserInformation userInformation)
        {
            _resultRepository = result;
            _mapper = mapper;
            _userInformation = userInformation;
        }

        public async Task<Result> CreateAsync(MatchResultClientDto matchResultDto,User user)
        {
            var result = _mapper.Map<Result>(matchResultDto);
            result.User = user;

            await _resultRepository.CreateAsync(result);

            return result;
        }

        public async Task<int> MatchCountAsync()
        {
            return await _resultRepository.GetCountAsync(_userInformation.UserId); 
        }

        public async Task<List<Result>> GetAsync()
        {
            return await _resultRepository.GetAsync(_userInformation.UserId); 
        }

        public async Task UpdateAsync(Result result)
        {
            
            await _resultRepository.UpdateAsync(result);
        }
    }
}
