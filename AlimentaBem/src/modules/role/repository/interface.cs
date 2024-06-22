namespace alimenta_bem.src.modules.role.repository;

public interface IRoleData
{
    Task<Role> Create(Role role);
}