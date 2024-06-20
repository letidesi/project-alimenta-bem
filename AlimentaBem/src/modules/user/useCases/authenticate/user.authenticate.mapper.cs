using alimenta.bem.providers;
using alimenta.bem.user.repository;
using alimenta.bem.modules.user.useCases.authenticate.dto.response;

namespace alimenta.bem.modules.user.useCases.create.mapper;

public class UserAuthenticateMapper : ResponseMapper<UserAuthenticateResponse, User>
{
    private readonly ICryptoProvider _criptoProvider;

    public UserAuthenticateMapper(ICryptoProvider cryptoProvider)
    {
        _criptoProvider = cryptoProvider;
    }

    public override UserAuthenticateResponse FromEntity(User u) => new()
    {
        Accesstoken = _criptoProvider.generateAccessToken(u),
        Refreshtoken = _criptoProvider.generateRefreshToken(u)
    };
}