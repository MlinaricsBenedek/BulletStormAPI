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

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.ELO = 800;
            await _userRepository.CreateAsync(user);
        }

        public async Task<UserEloDto?> GetAsync(LoginDto loginDto)
        {
           var user = await _userRepository.GetByNameAsync(loginDto.Name);
           if (user is null)
           { 
                //throw excp
           }
           if (user.Password.Equals(loginDto.Password))
           {
                var userdto= _mapper.Map<UserEloDto>(user);
                return userdto;
           }
            return null;
        }
    }
}
