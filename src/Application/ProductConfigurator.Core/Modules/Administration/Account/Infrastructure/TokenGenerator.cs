using IdentityModel;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using ProductConfigurator.Core.Modules.Administration.Users;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductConfigurator.Core.Modules.Administration.Account.Infrastructure;

public class TokenGenerator
{
    public const string ApiSecretConfigurationName = "ApiSecret";
    public const int ExpirationDays = 1;

    private readonly IConfiguration configuration;

    public TokenGenerator(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        string? secret = configuration.GetValue<string>(ApiSecretConfigurationName);
        if (secret is null)
        {
            throw new DomainException($"Api secret is not configured. Configure it in appsettings.json under {ApiSecretConfigurationName} key.");
        }

        JwtSecurityTokenHandler tokenHandler = new();
        byte[] key = Encoding.ASCII.GetBytes(secret);

        List<Claim> claims = new()
        {
            new Claim(JwtClaimTypes.Subject, user.Id),
            new Claim(JwtClaimTypes.Name, user.UserName ?? ""),
        };

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(ExpirationDays),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        string tokenString = tokenHandler.WriteToken(token);
        return tokenString;
    }
}
