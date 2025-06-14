namespace alimenta_bem.src.modules.organization.useCases.create.dto.request;

public class OrganizationCreateRequest
{
    public string name { get; set; }
    public string type { get; set; }
    public string? description { get; set; }
}