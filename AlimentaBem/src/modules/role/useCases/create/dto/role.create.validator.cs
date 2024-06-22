using alimenta.bem.helpers;
using smc_backend.Modules.role.Enum;
using alimenta.bem.modules.role.useCases.create.dto.request;

namespace alimenta.bem.modules.role.useCases.create.dto.validator;

public class Validator : Validator<RoleCreateRequest>
{
    public Validator(Localizer localizer)
    {
        var _localizer = localizer;

        RuleFor(request => request.UserId)
           .NotEmpty()
           .WithMessage(_localizer["user:UserIdRequired"]);

        RuleFor(request => request.Type)
             .IsEnumName(typeof(EnumRole))
             .WithMessage(_localizer["data:InvalidTypeParameter"]);
    }
}