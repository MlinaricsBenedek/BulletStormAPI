using AutoMapper;
using BulletStormAPI.Dto;
using BulletStormAPI.Model;

namespace BulletStormAPI.Helper
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
