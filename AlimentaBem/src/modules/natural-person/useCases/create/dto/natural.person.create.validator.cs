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
         .WithMessage(_localizer["natural.person:FirstNameRequired"]);

        RuleFor(request => request.lastName)
         .NotEmpty()
         .WithMessage(_localizer["natural.person:LastNameRequired"]);

        RuleFor(request => request.cpf)
         .NotEmpty()
         .WithMessage(_localizer["natural.person:CPFRequired"])
         .MaximumLength(11)
         .WithMessage(_localizer["natural.person:CPFSizeRequired"]);

        RuleFor(request => request.rg)
         .NotEmpty()
         .WithMessage(_localizer["natural.person:RGRequired"])
         .MinimumLength(5)
         .WithMessage(_localizer["natural.person:RGSizeMin"])
         .MaximumLength(12)
         .WithMessage(_localizer["natural.person:RGSizeMax"]);

        RuleFor(request => request.age)
         .NotEmpty()
         .WithMessage(_localizer["natural.person:AgeRequired"]);

        RuleFor(request => request.age)
         .NotEmpty()
         .WithMessage(_localizer["natural.person:AgeRequired"]);

        RuleFor(request => request.birthdayDate)
            .NotEmpty()
            .WithMessage(_localizer["natural.person:BirthdayDateRequired"]);
    }
}