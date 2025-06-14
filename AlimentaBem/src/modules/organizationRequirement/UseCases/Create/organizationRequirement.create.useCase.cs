using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta_bem.src.organization.requirement.repository;

namespace alimenta_bem.src.modules.organization.requirement.useCases.create.useCase;

public class OrganizationRequirementCreateUseCase
{
    private Localizer _localizer;
    public IOrganizationRequirementData _organizationRequirementData;

    public OrganizationRequirementCreateUseCase(AlimentaBemContext context, Localizer localizer)
    {
        _localizer = localizer;
        _organizationRequirementData = new OrganizationRequirementData(context);
    }

    public async Task<OrganizationRequirement> exec(OrganizationRequirement organizationRequirement)
    {
        var createOrganizationRequirement = await _organizationRequirementData.Create(organizationRequirement);

        if (createOrganizationRequirement is null)
            throw new Exception(_localizer["organizationRequirement:IndividualCreationFailed"]);

        return createOrganizationRequirement;
    }
}