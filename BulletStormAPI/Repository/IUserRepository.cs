using BulletStormAPI.Model;

namespace BulletStormAPI.Repository
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);

        Task<User?> GetAsync(int id);

        Task<User?> GetByNameAsync(string name);

        Task<User?> GetByIdAsync(int id);

    }
}