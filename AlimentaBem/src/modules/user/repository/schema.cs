using alimenta.bem.entity.metadata;
using alimenta_bem.src.modules.role.repository;
using alimenta_bem.src.natural.person.repository;

namespace alimenta_bem.src.modules.user.repository;

public class User : BaseEntity
{
    public virtual ICollection<Role>? Roles { get; set; }
    public virtual ICollection<NaturalPerson>? NaturalPersons { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}