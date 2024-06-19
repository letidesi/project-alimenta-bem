
using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using alimenta.bem.user.repository;
using alimenta.bem.role.repository;

namespace alimenta.bem.modules.providers;

public class CryptoService : ICryptoProvider
{
    private readonly string JWT_SECRET = Environment.GetEnvironmentVariable("JWT_SECRET");
    private readonly string privateKEY = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "private.key");

    public string generateAccessToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();

        var identityClaims = new ClaimsIdentity();

        identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
        identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Name, user.Name ?? ""));
        identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

        // set 
        var roleClaims = RolesIntoClaim(user.Roles);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT_SECRET));

        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var securityToken = handler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = "alimentabem",
            Audience = "AlimentaBem",
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

        identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));

        identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

        var signingCredentials = getSecurityKey();

        var securityToken = handler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = "alimentabem",
            Audience = "AlimentaBem",
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
            ValidIssuer = "alimentabem",
            ValidAudience = "AlimentaBem",
            RequireSignedTokens = true,
            IssuerSigningKey = signingCredentials.Key
        });

        return payload;
    }

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

    private IDictionary<string, object> RolesIntoClaim(ICollection<Role> roles)
    {
        var rolesArray = roles.Select(roles => roles.Type);

        return new Dictionary<string, object>(){
            { "roles", rolesArray },
        };
    }
}
