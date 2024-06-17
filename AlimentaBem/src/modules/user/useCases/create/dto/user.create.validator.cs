using alimenta.bem.helpers;
using alimenta.bem.modules.user.useCases.create.dto.request;

namespace alimenta.bem.modules.user.useCases.create.dto.validator;

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
            .WithMessage(_localizer["date:FormatOfEmailAddress"]);

        RuleFor(request => request.Password)
            .NotEmpty()
            .WithMessage(_localizer["date:PasswordRequired"])
            .MinimumLength(6)
            .WithMessage(_localizer["date:PasswordShort"])
            .MaximumLength(25)
            .WithMessage(_localizer["date:PasswordLong"]);
    }
}