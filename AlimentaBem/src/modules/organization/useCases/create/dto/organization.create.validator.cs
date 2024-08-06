using alimenta_bem.helpers;
using alimenta_bem.src.modules.organization.useCases.create.dto.request;

namespace alimenta_bem.src.modules.organization.useCases.create.dto.validator;

public class Validator : Validator<OrganizationCreateRequest>
{
    public Validator(Localizer localizer)
    {
        var _localizer = localizer;

        RuleFor(request => request.name)
         .NotEmpty()
         .WithMessage(_localizer["data:NameRequired"]);
        
        RuleFor(request => request.type)
         .NotEmpty()
         .WithMessage(_localizer["data:TypeRequired"]);
    }
}