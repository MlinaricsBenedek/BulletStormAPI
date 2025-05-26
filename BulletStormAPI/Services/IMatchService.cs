using BulletStormAPI.Dto;
using System.Threading.Tasks;

namespace BulletStormAPI.Services
{
    public interface IMatchService
    {
        Task UpdateAsync(MatchResultClientDto matchResultDto);

        Task CreateAsync(MatchResultClientDto matchResultDto);
    }
}