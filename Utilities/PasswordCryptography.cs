using System.Security.Cryptography;
using System.Text;

namespace HobbyTeamManager.Utilities;

// General idea from:
// https://stackoverflow.com/questions/4329909/hashing-passwords-with-md5-or-sha-256-c-sharp
// You should always salt the password before hashing when storing them in the database.
// Using "RandomNumberGenerator" because "RNGCryptoServiceProvider" is obsolete in .Net6
public class PasswordCryptography
{
    public struct HashSalt
    {
        public byte[] hash;
        public int salt;
    }

    public static HashSalt GenerateHashSaltFromPassword(string password)
    {
        var hs = new HashSalt();
        hs.salt = GenerateSalt();
        hs.hash = CalculateHash(password, hs.salt);
        return hs;
    }

    private static int GenerateSalt()
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            var saltBytes = new byte[4];

            rng.GetNonZeroBytes(saltBytes);

            int salt =
                (((int)saltBytes[0]) << 24) +
                (((int)saltBytes[1]) << 16) +
                (((int)saltBytes[2]) << 8) +
                ((int)saltBytes[3]);

            return salt;
        }
    }

    private static byte[] CalculateHash(string password, int salt)
    {
        var saltBytes = new byte[4];
        saltBytes[0] = (byte)(salt >> 24);
        saltBytes[1] = (byte)(salt >> 16);
        saltBytes[2] = (byte)(salt >> 8);
        saltBytes[3] = (byte)(salt);

        var passwordBytes = Encoding.UTF8.GetBytes(password);

        var passwordAndSaltBytes = new byte[saltBytes.Length + passwordBytes.Length];
        Buffer.BlockCopy(
            passwordBytes, 0, passwordAndSaltBytes, 0, passwordBytes.Length);
        Buffer.BlockCopy(
            saltBytes, 0, passwordAndSaltBytes, passwordBytes.Length, saltBytes.Length);

        var sha = SHA512.Create();
        return sha.ComputeHash(passwordAndSaltBytes);
    }

    public static bool IsPasswordCorrect(string password, HashSalt hs)
    {
        var hash = CalculateHash(password, hs.salt);
        return hash == hs.hash;
    }
}
