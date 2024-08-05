namespace alimenta_bem.src.organization.repository;

public interface IOrganizationData
{
    Task<Organization> Create(Organization organization);
}