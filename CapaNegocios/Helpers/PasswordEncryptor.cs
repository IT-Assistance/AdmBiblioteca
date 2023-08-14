using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CapaNegocios.Helpers
{
    public static class PasswordEncryptor
    {
        public static string EncryptPassword(string password)
        {
            int iterations = 10000; // Number of iterations for PBKDF2
            int saltLength = 16;     // Length of the salt in bytes
            int hashBytes = 32;      // Number of bytes in the generated hash

            byte[] salt = GenerateSalt(saltLength);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(hashBytes);
                byte[] hashPlusSalt = new byte[hashBytes + salt.Length];

                Buffer.BlockCopy(hash, 0, hashPlusSalt, 0, hashBytes);
                Buffer.BlockCopy(salt, 0, hashPlusSalt, hashBytes, salt.Length);

                return Convert.ToBase64String(hashPlusSalt);
            }
        }

        private static byte[] GenerateSalt(int saltLength)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[saltLength];
                rng.GetBytes(salt);
                return salt;
            }
        }
    }

}
