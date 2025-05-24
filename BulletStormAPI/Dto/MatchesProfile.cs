using AutoMapper;
using BulletStormAPI.Model;

namespace BulletStormAPI.Dto
{
    public class MatchesProfile : Profile
    {
        public MatchesProfile()
        {
            CreateMap<Statistics, MatchesDto>();
            CreateMap<Statistics, MatchesDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore()); ;
        }
    }
}
