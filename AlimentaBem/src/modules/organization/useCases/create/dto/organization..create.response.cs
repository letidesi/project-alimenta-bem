using alimenta.bem.entity.metadata;

namespace alimenta_bem.src.modules.organization.useCases.create.dto.response;

public class OrganizationCreateResponse : BaseEntity
{
    public string name { get; set; }
    public string? type { get; set; }
    public string? description { get; set; }
}