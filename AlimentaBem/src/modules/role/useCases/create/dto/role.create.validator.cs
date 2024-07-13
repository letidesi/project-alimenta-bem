using alimenta_bem.helpers;
using alimenta_bem.src.modules.role.@enum;
using alimenta_bem.src.modules.role.useCases.create.dto.request;

namespace alimenta_bem.modules.role.useCases.create.dto.validator;

public class Validator : Validator<RoleCreateRequest>
{
    public Validator(Localizer localizer)
    {
        var _localizer = localizer;

        RuleFor(request => request.userId)
           .NotEmpty()
           .WithMessage(_localizer["user:UserIdRequired"]);

        RuleFor(request => request.type)
             .IsEnumName(typeof(EnumRole))
             .WithMessage(_localizer["data:InvalidTypeParameter"]);
    }
}