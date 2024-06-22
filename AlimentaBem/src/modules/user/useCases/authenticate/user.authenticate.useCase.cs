using alimenta.bem.helpers;
using alimenta.bem.db.context;
using alimenta.bem.user.repository;
using alimenta.bem.modules.user.useCases.authenticate.dto.request;

namespace alimenta.bem.modules.user.useCases.authenticate.useCase;

public class UserAuthenticateUseCase
{
    private Localizer _localizer;
    public IUserData _user_data;
    public UserAuthenticateUseCase(AlimentaBemContext context, Localizer localizer)
    {
        _user_data = new UserData(context);
        _localizer = localizer;
    }

    public async Task<User> exec(UserAuthenticateRequest request)
    {
        var user = await _user_data.ReadOneByEmail(request.Email);
        if (user is null) throw new Exception(_localizer["user:UserNotFound"]);

        var passwordIsValid = FormatPassword.ComparePassword(request.Password, user.PasswordHash);
        if (!passwordIsValid)
            throw new Exception(_localizer["user:LoginInvalid"]);

        return user;
    }
}