using FootyConnect.Application.Abstractions;
using System.Security.Cryptography;

namespace FootyConnect.Infrastructure.Authentication;

public class PasswordHasher : IPasswordHasher
{
    public const int SaltSize = 16; // 128 bit
    public const int HashSize = 32; // 256 bit
    public const int Iterations = 100000; 

    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;    

    public string Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";    
    }

    public bool Verify(string password, string passwordHash)
    {
        string[] parts = passwordHash.Split('-');
        byte[] hash = Convert.FromHexString(parts[0]);
        byte[] salt = Convert.FromHexString(parts[1]);

        byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);
    
        return CryptographicOperations.FixedTimeEquals(hash, inputHash);
    }
}
