using System.Security.Cryptography;
using System.Text;

namespace VuexyBase.Application.Common.Helpers
{
    public static class HasherHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static byte[] GetPasswordHash(string password, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool ComparePasswordHash(string password, byte[] hash, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != hash[i])
                        return false;
                }
                return true;
            }
        }
    }
}
