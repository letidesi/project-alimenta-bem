using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta.bem.src.modules.organization.requirement.useCases.create.mapper;
using alimenta_bem.src.modules.organization.requirement.useCases.create.dto.request;
using alimenta_bem.src.modules.organization.requirement.useCases.create.dto.response;
using alimenta_bem.src.modules.organization.requirement.useCases.create.useCase;
using alimenta_bem.src.modules.role.@enum;

namespace alimenta_bem.src.modules.organization.requirement.useCases.create.endpoint;

public class organizationCreateEndPoint : Endpoint<OrganizationRequirementCreateRequest, OrganizationRequirementCreateResponse, OrganizationRequirementCreateMapper>
{
    public AlimentaBemContext _context { get; init; }
    public Localizer _localizer { get; init; }

    public override void Configure()
    {
        Post("organization-requirement");
        Options(n => n.WithTags("organization-requirement"));
        Roles(EnumRole.Admin.ToString());
        Summary(s =>
        {
            s.Summary = "Create a new organization requirement";
            s.Description = "Register a organization requirement on the platform";
        });
    }

    public override async Task HandleAsync(OrganizationRequirementCreateRequest req, CancellationToken ct)
    {
        try
        {
            var organizationRequirementCreateUseCase = new OrganizationRequirementCreateUseCase(_context, _localizer);

            var organizationRequirement = Map.ToEntity(req);

            var createOrganizationRequirement = await organizationRequirementCreateUseCase.exec(organizationRequirement);

            var createdOrganizationRequirement = Map.FromEntity(createOrganizationRequirement);

            await SendAsync(createdOrganizationRequirement);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}