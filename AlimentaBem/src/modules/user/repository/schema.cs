using alimenta.bem.entity.metadata;
using alimenta_bem.src.modules.role.repository;
using alimenta_bem.src.natural.person.repository;

namespace alimenta_bem.src.modules.user.repository;

public class User : BaseEntity
{
    public virtual ICollection<Role>? roles { get; set; }
    public virtual ICollection<NaturalPerson>? naturalPersons { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string passwordHash { get; set; }
}