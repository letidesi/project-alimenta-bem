namespace alimenta_bem.src.modules.organization.requirement.useCases.create.dto.request;

public class OrganizationRequirementCreateRequest
{
    public Guid organizationId { get; set; }
    public string itemName { get; set; }
    public int quantity { get; set; }
    public string type { get; set; }
}