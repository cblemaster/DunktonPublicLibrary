
namespace EFCorePractice.App.Cryptography;

public interface ITokenGenerator
{
    string GenerateToken(Guid accountId, string username);
    string GenerateToken(Guid accountId, string username, IEnumerable<string> roles);
}
