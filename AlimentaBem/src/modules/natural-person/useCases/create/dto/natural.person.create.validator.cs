using alimenta_bem.helpers;
using alimenta_bem.src.modules.natural.person.useCases.create.dto.request;

namespace alimenta_bem.src.modules.natural.person.useCases.create.dto.validator;

public class Validator : Validator<NaturalPersonCreateRequest>
{
    public Validator(Localizer localizer)
    {
        var _localizer = localizer;

        RuleFor(request => request.firstName)
         .NotEmpty()
         .WithMessage(_localizer["naturalPerson:FirstNameRequired"]);

        RuleFor(request => request.lastName)
         .NotEmpty()
         .WithMessage(_localizer["naturalPerson:LastNameRequired"]);

        RuleFor(request => request.age)
         .NotEmpty()
         .WithMessage(_localizer["naturalPerson:AgeRequired"]);

        RuleFor(request => request.age)
         .NotEmpty()
         .WithMessage(_localizer["naturalPerson:AgeRequired"]);

        RuleFor(request => request.birthdayDate)
            .NotEmpty()
            .WithMessage(_localizer["naturalPerson:BirthdayDateRequired"]);
    }
}