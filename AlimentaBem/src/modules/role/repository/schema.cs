using alimenta.bem.entity.metadata;
using alimenta_bem.src.modules.user.repository;

namespace alimenta_bem.src.modules.role.repository;

public class Role : BaseEntity
{
    public Guid userId { get; set; }
    public User user { get; set; }
    public string type { get; set; }
}