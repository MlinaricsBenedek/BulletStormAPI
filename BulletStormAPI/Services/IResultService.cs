using BulletStormAPI.Dto;
using BulletStormAPI.Model;

namespace BulletStormAPI.Services
{
    public interface IResultService
    {
        Task<Result> CreateAsync(MatchResultClientDto matchResultDto, User user);

        Task<List<Result>> GetAsync();

        Task<int> MatchCountAsync();

        Task UpdateAsync(Result result);
    }
}