using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DunktonPublicLibrary.App.Cryptography;

public sealed class JwtGenerator(string jwtSecret) : ITokenGenerator
{
    public string GenerateToken(Guid accountId, string username) => GenerateToken(accountId, username, []);

    public string GenerateToken(Guid accountId, string username, IEnumerable<string> roles)
    {
        List<Claim> claims =
        [
            new Claim("sub", accountId.ToString()),
            new Claim("name", username),
        ];

        foreach (string role in roles)
        {
            if (!string.IsNullOrWhiteSpace(role))
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Trim()));
            }
        }

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(claims),
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret)),
                SecurityAlgorithms.HmacSha256Signature),
        };

        JwtSecurityTokenHandler tokenHandler = new();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
