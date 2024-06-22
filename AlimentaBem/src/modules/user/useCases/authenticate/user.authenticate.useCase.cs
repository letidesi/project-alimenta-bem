using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta_bem.src.modules.user.repository;
using alimenta_bem.src.modules.user.useCases.authenticate.dto.request;

namespace alimenta_bem.src.modules.user.useCases.authenticate.UseCase;

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