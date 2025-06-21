using alimenta_bem.helpers;
using alimenta_bem.src.modules.natural.person.useCases.update.dto.request;

namespace alimenta_bem.src.modules.natural.person.useCases.update.dto.validator;

public class Validator : Validator<NaturalPersonUpdateRequest>
{
    public Validator(Localizer localizer)
    {
        var _localizer = localizer;

        RuleFor(request => request.name)
         .NotEmpty()
         .WithMessage(_localizer["naturalPerson:nameRequired"]);

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