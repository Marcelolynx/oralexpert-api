using System.Security.Cryptography;
using System.Text;

namespace Eleven.OralExpert.Core.Utilities;

public static class PasswordHasher
{
   private const int SaltSize = 16;
   private const int HashSize = 32;
   private const int Iterations = 1000;


   public static string HashPassword(string password)
   {
      using var rng = new RNGCryptoServiceProvider();
      var salt = new byte[SaltSize];
      rng.GetBytes(salt);

      using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
      var hash = pbkdf2.GetBytes(HashSize);

      var hashBytes = new byte[SaltSize + HashSize];
      Buffer.BlockCopy(salt, 0, hashBytes, 0, SaltSize);
      Buffer.BlockCopy(hash, 0, hashBytes, SaltSize, HashSize);

      return Convert.ToBase64String(hashBytes);
   }
   
   public static bool VerifyPassword(string password, string hashedPassword)
   {
       
      var hashBytes = Convert.FromBase64String(hashedPassword);

       
      var salt = new byte[SaltSize];
      Buffer.BlockCopy(hashBytes, 0, salt, 0, SaltSize);
      var storedHash = new byte[HashSize];
      Buffer.BlockCopy(hashBytes, SaltSize, storedHash, 0, HashSize);

       
      using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
      var computedHash = pbkdf2.GetBytes(HashSize);

       
      return CryptographicOperations.FixedTimeEquals(storedHash, computedHash);
   }
}