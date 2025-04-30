using BulletStormAPI.Dto;

namespace BulletStormAPI.Services
{
    public interface IUserService
    {
        Task CreateAsync(UserDto userDto);

        Task<UserEloDto?> GetAsync(LoginDto loginDto);
    }
}