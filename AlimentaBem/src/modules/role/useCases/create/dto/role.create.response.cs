using alimenta.bem.entity.metadata;

namespace alimenta_bem.src.modules.role.useCases.create.dto.response;

public class RoleCreateResponse : BaseEntity
{
    public Guid UserId { get; set; }
    public string Type { get; set; }
}