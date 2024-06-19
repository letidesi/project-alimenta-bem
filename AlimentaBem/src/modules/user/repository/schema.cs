using alimenta.bem.entity.metadata;
using alimenta.bem.role.repository;

namespace alimenta.bem.user.repository;

public class User : BaseEntity
{
    public virtual ICollection<Role>? Roles { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}