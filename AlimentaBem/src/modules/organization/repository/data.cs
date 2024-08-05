using alimenta_bem.helpers;
using alimenta_bem.db.context;

namespace alimenta_bem.src.organization.repository;

public class OrganizationData : IOrganizationData
{
    private readonly AlimentaBemContext _context;

    public OrganizationData(AlimentaBemContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<Organization> Create(Organization organization)
    {
        organization = (Organization)WhiteSpaces.RemoveFromAllStringProperty(organization);

        _context.Organizations.Add(organization);

        _ = await _context.SaveChangesAsync();

        return organization;
    }
}