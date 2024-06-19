using alimenta.bem.entity.metadata;
using alimenta.bem.user.repository;

namespace alimenta.bem.role.repository;

public class Role : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Type { get; set; }
}