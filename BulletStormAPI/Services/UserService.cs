using AutoMapper;
using BulletStormAPI.Dto;
using BulletStormAPI.Model;
using BulletStormAPI.Repository;

namespace BulletStormAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IStatisticsService _statisticsService;
        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher, ITokenGenerator tokenGenerator, IStatisticsService statisticsService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
            _statisticsService = statisticsService;
        }

        public async Task CreateAsync(UserDto userDto)
        {
            var user = _mapper.Map<User?>(userDto);
            user.Password = _passwordHasher.Hash(userDto.Password);
            
            user = await _userRepository.CreateAsync(user);
            await _statisticsService.CreateAsync(user.Id);
        }

        public async Task<User?> GetById(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<UserEloDto?> GetAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByNameAsync(loginDto.Name);
            if (user is null)
            {
                return null;
            }
            var userdto = _mapper.Map<UserEloDto>(user);
            return userdto;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByNameAsync(loginDto.Name);
            if (user is null)
            {
                return null;
            }
            if (_passwordHasher.Verify(user.Password, loginDto.Password))
            {

                return _tokenGenerator.GenerateToken(user);
            }
            return null;
        }
    }
}
