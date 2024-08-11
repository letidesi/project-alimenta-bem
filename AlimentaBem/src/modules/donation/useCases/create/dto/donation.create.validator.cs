using alimenta_bem.helpers;
using alimenta_bem.src.modules.donation.useCases.create.dto.request;

namespace alimenta_bem.src.modules.donation.useCases.create.dto.validator;

public class Validator : Validator<DonationCreateRequest>
{
    public Validator(Localizer localizer)
    {
        var _localizer = localizer;

        RuleFor(request => request.naturalPersonId)
         .NotEmpty()
         .WithMessage(_localizer["naturalPerson:NaturalPersonIdRequired"]);

        RuleFor(request => request.organizationId)
         .NotEmpty()
         .WithMessage(_localizer["organization:OrganizationIdRequired"]);

        RuleFor(request => request.itemName)
         .NotEmpty()
         .WithMessage(_localizer["donation:ItemNameRequired"]);

        RuleFor(request => request.amountDonated)
         .NotEmpty()
         .WithMessage(_localizer["donation:AmountDonatedRequired"]);
    }
}