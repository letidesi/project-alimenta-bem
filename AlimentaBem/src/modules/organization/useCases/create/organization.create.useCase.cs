using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta_bem.src.organization.repository;

namespace alimenta_bem.src.modules.organization.useCases.create.useCase;

public class OrganizationCreateUseCase
{
    private Localizer _localizer;
    public IOrganizationData _organization_data;

    public OrganizationCreateUseCase(AlimentaBemContext context, Localizer localizer)
    {
        _localizer = localizer;
        _organization_data = new OrganizationData(context);
    }

    public async Task<Organization> exec(Organization naturalPerson)
    {

        var create_organization = await _organization_data.Create(naturalPerson);
        if (create_organization is null)
            throw new Exception(_localizer["organization:IndividualCreationFailed"]);

        return create_organization;
    }
}