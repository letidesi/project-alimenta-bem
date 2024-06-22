using alimenta.bem.helpers;
using alimenta.bem.modules.user.useCases.authenticate.dto.request;

namespace alimenta.bem.modules.user.useCases.authenticate.dto.validator;

public class Validator : Validator<UserAuthenticateRequest>
{
    public Validator(Localizer localizer)
    {
        var _localizer = localizer;

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