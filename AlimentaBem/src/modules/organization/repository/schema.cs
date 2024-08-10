using alimenta.bem.entity.metadata;
using alimenta_bem.src.organization.@enum;
using alimenta_bem.src.donation.repository;
using alimenta_bem.src.organization.requirement.repository;

namespace alimenta_bem.src.organization.repository;

public class Organization : BaseEntity
{
    public virtual ICollection<Donation>? donations { get; set; }
    public virtual ICollection<OrganizationRequirement>? OrganizationRequirements { get; set; }
    public string name { get; set; }
    public TypeOrganization? type { get; set; }
    public string? description { get; set; }
}