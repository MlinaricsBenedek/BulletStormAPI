using BulletStormAPI.Model;

namespace BulletStormAPI.Services
{
    public interface ITokenGenerator
    {
        public string GenerateToken(User user);
    }
}
