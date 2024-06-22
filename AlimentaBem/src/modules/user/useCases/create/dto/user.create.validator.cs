using alimenta_bem.helpers;
using alimenta_bem.src.modules.user.useCases.create.dto.request;

namespace alimenta_bem.src.modules.user.useCases.create.dto.validator;

public class Validator : Validator<UserCreateRequest>
{
    public Validator(Localizer localizer)
    {
        var _localizer = localizer;

        RuleFor(request => request.Name)
           .NotEmpty()
           .WithMessage(_localizer["data:NameRequired"]);

        RuleFor(request => request.Email)
            .NotEmpty()
            .WithMessage(_localizer["data:EmailRequired"])
            .EmailAddress()
            .WithMessage(_localizer["data:FormatOfEmailAddress"]);

        RuleFor(request => request.Password)
            .NotEmpty()
            .WithMessage(_localizer["user:PasswordRequired"])
            .MinimumLength(6)
            .WithMessage(_localizer["user:PasswordShort"])
            .MaximumLength(25)
            .WithMessage(_localizer["user:PasswordLong"]);
    }
}