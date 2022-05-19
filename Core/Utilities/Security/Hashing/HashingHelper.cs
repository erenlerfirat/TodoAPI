using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public static class HashingHelper
    {
        public static void CreatePasswordHash(string password , out byte[] passwordSalt,out byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) 
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash()
        {
            return true; 
        }
    }
}
