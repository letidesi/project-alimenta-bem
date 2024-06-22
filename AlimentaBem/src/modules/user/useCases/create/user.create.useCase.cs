using alimenta_bem.db.context;
using alimenta_bem.helpers;
using alimenta_bem.src.modules.user.repository;

namespace alimenta_bem.src.modules.user.useCases.create.useCase;

public class UserCreateUseCase
{
    private Localizer _localizer;
    public IUserData _user_data;
    public Is_Valid_Email_Function is_Valid_Email_Function { get; set; }
    public UserCreateUseCase(AlimentaBemContext context, Localizer localizer)
    {
        _user_data = new UserData(context);
        _localizer = localizer;
        is_Valid_Email_Function = new Is_Valid_Email_Function();
    }

    public async Task<User> exec(User user)
    {
        var email_validation = is_Valid_Email_Function.Is_Valid_Email(user.Email);
        if (email_validation is false) throw new Exception(_localizer["data:EmailInvalid"]);

        var existing_user = await _user_data.ReadOneByEmail(user.Email);
        if (existing_user is not null)
            throw new Exception(_localizer["user:UserSameEmail"]);

        var create_user = await _user_data.Create(user);
        return create_user;
    }
}