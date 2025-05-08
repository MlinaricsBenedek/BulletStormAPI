using AutoMapper;
using BulletStormAPI.Model;

namespace BulletStormAPI.Dto
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}
