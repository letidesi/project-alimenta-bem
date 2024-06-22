using alimenta.bem.entity.metadata;
using alimenta_bem.src.modules.user.repository;

namespace alimenta_bem.src.modules.role.repository;

public class Role : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Type { get; set; }
}