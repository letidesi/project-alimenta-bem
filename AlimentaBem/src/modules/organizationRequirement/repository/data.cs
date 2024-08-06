using alimenta_bem.helpers;
using alimenta_bem.db.context;

namespace alimenta_bem.src.organization.requirement.repository;

public class OrganizationRequirementData : IOrganizationRequirementData
{
    private readonly AlimentaBemContext _context;

    public OrganizationRequirementData(AlimentaBemContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<OrganizationRequirement> Create(OrganizationRequirement organizationRequirement)
    {
        organizationRequirement = (OrganizationRequirement)WhiteSpaces.RemoveFromAllStringProperty(organizationRequirement);

        _context.OrganizationRequirements.Add(organizationRequirement);

        _ = await _context.SaveChangesAsync();

        return organizationRequirement;
    }
}