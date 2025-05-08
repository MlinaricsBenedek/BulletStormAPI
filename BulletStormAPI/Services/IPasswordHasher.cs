namespace BulletStormAPI.Services
{
    public interface IPasswordHasher
    {
        string Hash(string plainText);
        bool Verify(string hashedPassword, string inputPassword);
    }
}