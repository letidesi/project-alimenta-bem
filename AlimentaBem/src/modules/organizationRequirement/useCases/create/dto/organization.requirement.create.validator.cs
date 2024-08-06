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
         .WithMessage(_localizer["natural.person:FirstNameRequied"]);

        RuleFor(request => request.name)
         .NotEmpty()
         .WithMessage(_localizer["data:NameRequired"]);

        RuleFor(request => request.type)
         .NotEmpty()
         .WithMessage(_localizer["date.person:CPFRequired"]);
    }
}