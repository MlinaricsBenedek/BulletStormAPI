using AutoMapper;
using BulletStormAPI.Model;

namespace BulletStormAPI.Dto
{
    public class MatchResultClientDtoProfile: Profile
    {
        public MatchResultClientDtoProfile()
        {
            CreateMap<MatchResultClientDto, Result>().ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Kill, opt => opt.MapFrom(src => src.ResulClient.Kill))
                .ForMember(dest => dest.Assist, opt => opt.MapFrom(src=>src.ResulClient.Assist))
                .ForMember(dest => dest.Deaths, opt => opt.MapFrom(src => src.ResulClient.Deaths))
                .ForMember(dest => dest.Won, opt => opt.MapFrom(src => src.ResulClient.Won));
        }
    }
}
