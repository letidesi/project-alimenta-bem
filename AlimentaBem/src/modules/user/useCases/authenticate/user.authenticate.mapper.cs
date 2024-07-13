using alimenta_bem.src.providers.crypto;
using alimenta_bem.src.modules.user.repository;
using alimenta_bem.src.modules.user.useCases.authenticate.dto.response;

namespace alimenta_bem.src.modules.user.useCases.authenticate.mapper;

public class UserAuthenticateMapper : ResponseMapper<UserAuthenticateResponse, User>
{
    private readonly ICryptoProvider _criptoProvider;

    public UserAuthenticateMapper(ICryptoProvider cryptoProvider)
    {
        _criptoProvider = cryptoProvider;
    }

    public override UserAuthenticateResponse FromEntity(User u) => new()
    {
        accesstoken = _criptoProvider.generateAccessToken(u),
        refreshtoken = _criptoProvider.generateRefreshToken(u)
    };
}