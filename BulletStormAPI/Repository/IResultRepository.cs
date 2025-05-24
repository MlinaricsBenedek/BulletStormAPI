using BulletStormAPI.Model;

namespace BulletStormAPI.Repository
{
    public interface IResultRepository
    {
        Task<Result?> CreateAsync(Result result);

        Task<List<Result?>> GetAsync(int userId);

        Task UpdateAsync(Result result);

        Task<int> GetCountAsync(int userId);
    }
}