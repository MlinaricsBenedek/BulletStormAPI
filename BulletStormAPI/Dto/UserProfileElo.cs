using AutoMapper;
using BulletStormAPI.Model;

namespace BulletStormAPI.Dto
{
    public class UserProfileElo : Profile
    {
        public UserProfileElo()
        {
            CreateMap<User, UserEloDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        }
    }
}
