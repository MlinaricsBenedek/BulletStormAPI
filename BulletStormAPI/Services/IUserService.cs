using BulletStormAPI.Dto;
using BulletStormAPI.Model;

namespace BulletStormAPI.Services
{
    public interface IUserService
    {
        Task CreateAsync(UserDto userDto);

        Task<UserEloDto?> GetAsync(LoginDto loginDto);

        Task<string> LoginAsync(LoginDto loginDto);

        Task<User?> GetById(int id);
    }
}