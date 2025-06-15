using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta_bem.src.modules.user.repository;
using alimenta_bem.src.organization.repository;

namespace alimenta_bem.src.modules.organization.useCases.readList.useCase;

public class OrganizationReadListUseCase
{
    private Localizer _localizer;
    public IUserData _userData;
    public IOrganizationData _organizationData;
   
    public OrganizationReadListUseCase(AlimentaBemContext context, Localizer localizer)
    {
        _localizer = localizer;
        _organizationData = new OrganizationData(context);
    }

    public async Task<List<Organization>> exec()
    {
  
        var organizations = await _organizationData.ReadList();
        if (organizations.Count == 0)
            throw new Exception(_localizer["organization:UserNotFound"]);

        return organizations;
    }
}