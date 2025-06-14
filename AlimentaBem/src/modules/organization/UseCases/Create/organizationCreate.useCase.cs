using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta_bem.src.organization.repository;

namespace alimenta_bem.src.modules.organization.useCases.create.useCase;

public class OrganizationCreateUseCase
{
    private Localizer _localizer;
    public IOrganizationData _organizationData;

    public OrganizationCreateUseCase(AlimentaBemContext context, Localizer localizer)
    {
        _localizer = localizer;
        _organizationData = new OrganizationData(context);
    }

    public async Task<Organization> exec(Organization naturalPerson)
    {

        var createOrganization = await _organizationData.Create(naturalPerson);
        if (createOrganization is null)
            throw new Exception(_localizer["organization:IndividualCreationFailed"]);

        return createOrganization;
    }
}