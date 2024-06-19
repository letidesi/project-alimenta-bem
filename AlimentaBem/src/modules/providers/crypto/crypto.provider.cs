using Microsoft.IdentityModel.Tokens;
using alimenta.bem.user.repository;

namespace alimenta.bem.modules.providers;

public interface ICryptoProvider
{
    string generateAccessToken(User user);
    string generateRefreshToken(User user);
    Task<TokenValidationResult> validateRefreshToken(string token);
}