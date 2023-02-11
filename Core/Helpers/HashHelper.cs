using System;
using System.Security.Cryptography;

namespace Core.Helpers
{
    public static class HashHelper
    {
        private const int SaltSize = 16; // 128 bits
        private const int KeySize = 32; // 256 bits
        private const int Iterations = 100000;
        private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;

        private const char segmentDelimiter = ':';

        public static string Hash(string password , out string passwordHash)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, KeySize);
            passwordHash = string.Join(segmentDelimiter, Convert.ToHexString(hash), Convert.ToHexString(salt), Iterations, Algorithm);
            return passwordHash;
        }

        public static bool Verify(string password, string hashString)
        {
            string[] segments = hashString.Split(segmentDelimiter);
            byte[] hash = Convert.FromHexString(segments[0]);
            byte[] salt = Convert.FromHexString(segments[1]);
            int iterations = int.Parse(segments[2]);
            HashAlgorithmName algorithm = new HashAlgorithmName(segments[3]);
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations,
                algorithm,
                hash.Length
            );
            return CryptographicOperations.FixedTimeEquals(inputHash, hash);
        }
    }
}
