using AutoMapper;
using BulletStormAPI.Model;

namespace BulletStormAPI.Dto
{
    public class ResultDtoProfile : Profile
    {
        public ResultDtoProfile()
        {
            CreateMap<Result, ResultDto>();
        }
    }
}
