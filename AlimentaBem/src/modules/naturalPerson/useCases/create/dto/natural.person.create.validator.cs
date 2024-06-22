using alimenta.bem.helpers;
using alimenta.bem.modules.natural.person.useCases.create.dto.request;

namespace alimenta.bem.modules.natural.person.useCases.create.dto.validator;

public class Validator : Validator<NaturalPersonCreateRequest>
{
    public Validator(Localizer localizer)
    {
        var _localizer = localizer;

        RuleFor(request => request.FirstName)
         .NotEmpty()
         .WithMessage(_localizer["natural.person:FirstNameRequired"]);

        RuleFor(request => request.LastName)
         .NotEmpty()
         .WithMessage(_localizer["natural.person:LastNameRequired"]);

        RuleFor(request => request.Cpf)
         .NotEmpty()
         .WithMessage(_localizer["natural.person:CPFRequired"])
         .MaximumLength(11)
         .WithMessage(_localizer["natural.person:CPFSizeRequired"]);

        RuleFor(request => request.Rg)
         .NotEmpty()
         .WithMessage(_localizer["natural.person:RGRequired"])
         .MinimumLength(5)
         .WithMessage(_localizer["natural.person:RGSizeMin"])
         .MaximumLength(12)
         .WithMessage(_localizer["natural.person:RGSizeMax"]);

        RuleFor(request => request.Age)
         .NotEmpty()
         .WithMessage(_localizer["natural.person:AgeRequired"]);

        RuleFor(request => request.Age)
         .NotEmpty()
         .WithMessage(_localizer["natural.person:AgeRequired"]);

        RuleFor(request => request.BirthdayDate)
            .NotEmpty()
            .WithMessage(_localizer["natural.person:BirthdayDateRequired"]);
    }
}