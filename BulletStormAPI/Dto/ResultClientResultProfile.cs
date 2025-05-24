using AutoMapper;
using BulletStormAPI.Model;

namespace BulletStormAPI.Dto
{
    public class ResultClientResultProfile:Profile
    {
        public ResultClientResultProfile()
        {
            CreateMap<ResulClientDto,Result>();
        }
    }
}
