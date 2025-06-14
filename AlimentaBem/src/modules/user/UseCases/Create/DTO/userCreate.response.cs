using alimenta.bem.entity.metadata;

namespace alimenta_bem.src.modules.user.useCases.create.dto.response;

public class UserCreateResponse : BaseEntity
{
    public string name { get; set; }
    public string email { get; set; }
    public string passwordHash { get; set; }
}