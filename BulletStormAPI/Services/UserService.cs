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

        public UserService(IUserRepository userRepository, IMapper mapper,IPasswordHasher passwordHasher, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
        }

        public async Task CreateAsync(UserDto userDto)
        {
            var user = _mapper.Map<User?>(userDto);
            user.ELO = 800;
            user.Password = _passwordHasher.Hash(userDto.Password);
            await _userRepository.CreateAsync(user);
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
