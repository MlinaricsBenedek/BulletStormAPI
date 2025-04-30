using BulletStormAPI.Model;

namespace BulletStormAPI.Repository
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);

        Task<User?> GetAsync(int id);

        Task<User?> GetByNameAsync(string name);
    }
}