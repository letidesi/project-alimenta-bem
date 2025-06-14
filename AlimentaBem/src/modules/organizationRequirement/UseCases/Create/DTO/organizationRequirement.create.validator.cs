using alimenta_bem.helpers;
using alimenta_bem.src.modules.organization.requirement.useCases.create.dto.request;

namespace alimenta_bem.src.modules.organization.requirement.useCases.create.dto.validator;

public class Validator : Validator<OrganizationRequirementCreateRequest>
{
    public Validator(Localizer localizer)
    {
        var _localizer = localizer;

        RuleFor(request => request.organizationId)
        .NotEmpty()
        .WithMessage(_localizer["organization:OrganizationIdRequired"]);

        RuleFor(request => request.itemName)
        .NotEmpty()
        .WithMessage(_localizer["organizationRequirement:ItemNameRequired"]);

        RuleFor(request => request.quantity)
        .NotEmpty()
        .WithMessage(_localizer["organizationRequirement:QuantityRequired"]);

        RuleFor(request => request.type)
        .NotEmpty()
        .WithMessage(_localizer["data:TypeRequired"]);
    }
}