using AutoMapper;
using BulletStormAPI.Model;

namespace BulletStormAPI.Dto
{
    public class MatchResultDtoProfile : Profile
    {
        public MatchResultDtoProfile()
        {
            CreateMap<MatchResultDto, Result>().ForMember(dest => dest.Id, opt => opt.Ignore()); ;
            // CreateMap<MatchResultDto, Result>().ReverseMap();
        }
    }
}
