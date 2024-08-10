using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta_bem.src.organization.requirement.repository;

namespace alimenta_bem.src.modules.organization.requirement.useCases.create.useCase;

public class OrganizationRequirementCreateUseCase
{
    private Localizer _localizer;
    public IOrganizationRequirementData _organization_requirement_data;

    public OrganizationRequirementCreateUseCase(AlimentaBemContext context, Localizer localizer)
    {
        _localizer = localizer;
        _organization_requirement_data = new OrganizationRequirementData(context);
    }

    public async Task<OrganizationRequirement> exec(OrganizationRequirement organizationRequirement)
    {
        var create_organization_requirement = await _organization_requirement_data.Create(organizationRequirement);

        if (create_organization_requirement is null)
            throw new Exception(_localizer["organizationRequirement:IndividualCreationFailed"]);

        return create_organization_requirement;
    }
}