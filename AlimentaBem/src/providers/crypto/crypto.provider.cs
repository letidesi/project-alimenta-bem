using Microsoft.IdentityModel.Tokens;
using alimenta_bem.src.modules.user.repository;

namespace alimenta_bem.src.providers.crypto;

public interface ICryptoProvider
{
    string generateAccessToken(User user);
    string generateRefreshToken(User user);
    Task<TokenValidationResult> validateRefreshToken(string token);
}