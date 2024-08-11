
using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using alimenta_bem.src.modules.role.repository;
using alimenta_bem.src.modules.user.repository;

namespace alimenta_bem.src.providers.crypto;

public class CryptoService : ICryptoProvider
{
    private readonly string JWT_SECRET = Environment.GetEnvironmentVariable("JWT_SECRET");
    private readonly string privateKEY = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "private.key");

    private SigningCredentials getSecurityKey()
    {
        var rsa = new RSACryptoServiceProvider();

        rsa.ImportFromPem(privateKEY);

        var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
        {
            CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
        };

        return signingCredentials;
    }

    public string generateAccessToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();

        var identityClaims = new ClaimsIdentity();

        identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.id.ToString()));
        identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Name, user.name ?? ""));
        identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Email, user.email));
        identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

        // set 
        var roleClaims = RolesIntoClaim(user.roles);


        var signingCredentials = getSecurityKey();

        var securityToken = handler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = "Alimentabem",
            Audience = "ABem",
            SigningCredentials = signingCredentials,
            Subject = identityClaims,
            Claims = roleClaims,
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddHours(1),
            IssuedAt = DateTime.UtcNow,
            TokenType = "at+jwt"
        });

        return handler.WriteToken(securityToken);
    }

    public string generateRefreshToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();

        var identityClaims = new ClaimsIdentity();

        identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.id.ToString()));

        identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

        var signingCredentials = getSecurityKey();

        var securityToken = handler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = "Alimentabem",
            Audience = "ABem",
            SigningCredentials = signingCredentials,
            Subject = identityClaims,
            NotBefore = DateTime.UtcNow.Date,
            Expires = DateTime.UtcNow.Date.AddDays(30),
            IssuedAt = DateTime.UtcNow,
            TokenType = "rt+jwt"
        });

        return handler.WriteToken(securityToken);
    }

    public async Task<TokenValidationResult> validateRefreshToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        var signingCredentials = getSecurityKey();

        var payload = await handler.ValidateTokenAsync(token, new TokenValidationParameters()
        {
            ValidIssuer = "Alimentabem",
            ValidAudience = "ABem",
            ValidateIssuer = true,
            ValidateAudience = true,
            RequireSignedTokens = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingCredentials.Key
        });

        return payload;
    }


    private IDictionary<string, object> RolesIntoClaim(ICollection<Role> roles)
    {
        var rolesArray = roles.Select(roles => roles.type).ToList();

        return new Dictionary<string, object>(){
            { "roles", rolesArray },
        };
    }
}
