using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta.bem.src.modules.organization.requirement.useCases.create.mapper;
using alimenta_bem.src.modules.organization.requirement.useCases.create.dto.request;
using alimenta_bem.src.modules.organization.requirement.useCases.create.dto.response;
using alimenta_bem.src.modules.organization.requirement.useCases.create.useCase;

namespace alimenta_bem.src.modules.organization.requirement.useCases.create.endpoint;

public class organizationCreateEndPoint : Endpoint<OrganizationRequirementCreateRequest, OrganizationRequirementCreateResponse, OrganizationRequirementCreateMapper>
{
    public AlimentaBemContext _context { get; init; }
    public Localizer _localizer { get; init; }

    public override void Configure()
    {
        Post("organization-requirement");
        Options(n => n.WithTags("organization-requirement"));
        Summary(s =>
        {
            s.Summary = "Create a new organization requirement";
            s.Description = "Register a organization requirement on the platform";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(OrganizationRequirementCreateRequest req, CancellationToken ct)
    {
        try
        {
            var organizationRequirementCreateUseCase = new OrganizationRequirementCreateUseCase(_context, _localizer);

            var organization_requirement = Map.ToEntity(req);

            var create_organization_requirement = await organizationRequirementCreateUseCase.exec(organization_requirement);

            var created_organization_requirement = Map.FromEntity(create_organization_requirement);

            await SendAsync(created_organization_requirement);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}