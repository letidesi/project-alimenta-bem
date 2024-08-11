using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta_bem.src.providers.crypto;
using alimenta_bem.src.modules.user.repository;
using alimenta_bem.src.modules.user.useCases.authenticate.dto.request;
using alimenta_bem.src.modules.user.useCases.authenticate.dto.response;

namespace alimenta_bem.src.modules.user.useCases.authenticate.UseCase;

public class UserAuthenticateUseCase
{
    private Localizer _localizer;
    private readonly ICryptoProvider _criptoProvider;
    public UserAuthenticateUseCase(Localizer localizer, ICryptoProvider cryptoProvider)
    {
        _localizer = localizer;
        _criptoProvider = cryptoProvider;
    }

    public UserAuthenticateResponse exec(UserAuthenticateRequest request, User user)
    {
        var passwordIsValid = FormatPassword.ComparePassword(request.password, user.passwordHash);
        if (!passwordIsValid)
            throw new Exception(_localizer["user:LoginInvalid"]);

        var tokens = new UserAuthenticateResponse()
        {
            accesstoken = _criptoProvider.generateAccessToken(user),
            refreshtoken = _criptoProvider.generateRefreshToken(user)
        };

        return tokens;
    }
}