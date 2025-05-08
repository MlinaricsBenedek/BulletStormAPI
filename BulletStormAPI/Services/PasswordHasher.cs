using System.Security.Cryptography;

namespace BulletStormAPI.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int Saltsize = 128 / 8;
        private const int KeySize = 128 / 8;
        private const int Iterator = 10000;
        private static readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;
        private static char delimeter = ';';

        public string Hash(string plainText)
        {
            var salt = RandomNumberGenerator.GetBytes(Saltsize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(plainText, salt, Iterator, hashAlgorithm, KeySize);
            return string.Join(delimeter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        public bool Verify(string hashedPassword, string inputPassword)
        {
            var elements = hashedPassword.Split(delimeter);
            var salt = Convert.FromBase64String(elements[0]);
            var hash = Convert.FromBase64String(elements[1]);
            var hashInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, Iterator, hashAlgorithm, KeySize);
            return CryptographicOperations.FixedTimeEquals(hash, hashInput);
        }
    }
}
