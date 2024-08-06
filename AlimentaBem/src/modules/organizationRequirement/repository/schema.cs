using alimenta.bem.entity.metadata;
using alimenta_bem.src.organization.requirement.@enum;

namespace alimenta_bem.src.organization.requirement.repository;

public class OrganizationRequirement : BaseEntity
{
    public Guid organizationId { get; set; }
    public string name { get; set; }
    public int quantity { get; set; }
    public Priority type { get; set; }
}