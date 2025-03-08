using System.Security.Cryptography;

namespace DunktonPublicLibrary.App.Cryptography;

public sealed class PasswordHasher : IPasswordHasher
{
    private const int ITERATIONS = 10000;

    public PasswordHash ComputeHash(string plainTextPassword)
    {
        Rfc2898DeriveBytes rfc = new(plainTextPassword, saltSize: 8, iterations: ITERATIONS, HashAlgorithmName.SHA256);
        byte[] hash = rfc.GetBytes(20);
        string salt = Convert.ToBase64String(rfc.Salt);
        return new(Convert.ToBase64String(hash), salt);
    }

    public bool VerifyHashMatch(string existingHashedPassword, string plainTextPassword, string salt)
    {
        byte[] saltArray = Convert.FromBase64String(salt);
        Rfc2898DeriveBytes rfc = new(plainTextPassword, saltArray, iterations: ITERATIONS, HashAlgorithmName.SHA256);
        byte[] hash = rfc.GetBytes(20);
        string newHashedPassword = Convert.ToBase64String(hash);
        return existingHashedPassword == newHashedPassword;
    }
}
