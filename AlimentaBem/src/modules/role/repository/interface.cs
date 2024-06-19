using alimenta.bem.role.repository;

namespace alimenta.bem.role.repository;

public interface IRoleData
{
    Task<Role> Create(Role role);
}