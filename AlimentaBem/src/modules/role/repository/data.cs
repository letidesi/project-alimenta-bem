using alimenta.bem.helpers;
using alimenta.bem.db.context;

namespace alimenta.bem.role.repository;

public class RoleData : IRoleData
{
    private readonly AlimentaBemContext _context;

    public RoleData(AlimentaBemContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<Role> Create(Role role)
    {
        role = (Role)WhiteSpaces.RemoveFromAllStringProperty(role);

        _context.Roles.Add(role);

        _ = await _context.SaveChangesAsync();

        return role;
    }
}