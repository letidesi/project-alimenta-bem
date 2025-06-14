namespace alimenta_bem.src.modules.role.useCases.create.dto.request;

public class RoleCreateRequest
{
    public Guid userId { get; set; }
    public string type { get; set; }
}