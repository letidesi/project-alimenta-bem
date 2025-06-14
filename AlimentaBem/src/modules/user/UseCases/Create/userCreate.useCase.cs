using alimenta_bem.db.context;
using alimenta_bem.helpers;
using alimenta_bem.src.modules.role.@enum;
using alimenta_bem.src.modules.role.repository;
using alimenta_bem.src.modules.user.repository;

namespace alimenta_bem.src.modules.user.useCases.create.useCase;

public class UserCreateUseCase
{
    private Localizer _localizer;
    public IUserData _userData;
    public isValidEmailFunction isValidEmailFunction { get; set; }
    public UserCreateUseCase(AlimentaBemContext context, Localizer localizer)
    {
        _userData = new UserData(context);
        _localizer = localizer;
        isValidEmailFunction = new isValidEmailFunction();
    }

    public async Task<User> exec(User user)
    {
        var emailValidation = isValidEmailFunction.IsValidEmail(user.email);
        if (emailValidation is false) throw new Exception(_localizer["data:EmailInvalid"]);

        var existingUser = await _userData.ReadOneByEmail(user.email);
        if (existingUser is not null)
            throw new Exception(_localizer["user:UserSameEmail"]);

        user.roles = new List<Role>()
        {
           new Role()
           {
                type = Enum.GetName(EnumRole.Citizen)
           }
        };

        var create_user = await _userData.Create(user);
        return create_user;
    }
}