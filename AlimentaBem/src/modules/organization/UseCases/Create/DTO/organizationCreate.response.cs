namespace alimenta_bem.src.modules.organization.useCases.create.dto.response;

public class OrganizationCreateResponse
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string? type { get; set; }
    public string? description { get; set; }
    public DateTimeOffset createdAt { get; set; }
    public DateTimeOffset? updatedAt { get; set; }
}