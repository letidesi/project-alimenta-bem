namespace alimenta_bem.src.organization.requirement.repository;

public interface IOrganizationRequirementData
{
    Task<OrganizationRequirement> Create(OrganizationRequirement organizationRequirement);
}