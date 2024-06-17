using alimenta.bem.entity.metadata;

namespace alimenta.bem.user.repository;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}