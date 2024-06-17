using alimenta.bem.entity.metadata;

namespace alimenta.bem.modules.user.useCases.create.dto.response;

public class UserCreateResponse : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}