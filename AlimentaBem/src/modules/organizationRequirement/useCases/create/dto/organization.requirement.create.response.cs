using alimenta.bem.entity.metadata;

namespace alimenta_bem.src.modules.organization.requirement.useCases.create.dto.response;

public class OrganizationRequirementCreateResponse : BaseEntity
{
    public Guid organizationId { get; set; }
    public string name { get; set; }
    public int quantity { get; set; }
    public string type { get; set; }
}