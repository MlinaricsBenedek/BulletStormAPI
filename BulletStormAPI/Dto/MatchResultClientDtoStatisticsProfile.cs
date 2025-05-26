using AutoMapper;
using BulletStormAPI.Model;

namespace BulletStormAPI.Dto
{
    public class MatchResultClientDtoStatisticsProfile:Profile
    {
        public MatchResultClientDtoStatisticsProfile()
        {

            CreateMap<MatchResultClientDto, Statistics>().ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.AggregatedKills, opt => opt.MapFrom(src => src.ResulClient.Kill))
                .ForMember(dest => dest.AggregatedAssits, opt => opt.MapFrom(src => src.ResulClient.Assist))
                .ForMember(dest => dest.AggregatedDeath, opt => opt.MapFrom(src => src.ResulClient.Deaths));


            CreateMap<MatchResultClientDto, Statistics>().ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.AggregatedKills, opt => opt.MapFrom(src => src.ResulClient.Kill))
                .ForMember(dest => dest.AggregatedAssits, opt => opt.MapFrom(src => src.ResulClient.Assist))
                .ForMember(dest => dest.AggregatedDeath, opt => opt.MapFrom(src => src.ResulClient.Deaths)).ReverseMap();

        }
    }
}
