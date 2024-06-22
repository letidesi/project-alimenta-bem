using alimenta.bem.helpers;
using alimenta.bem.db.context;
using alimenta.bem.role.repository;

namespace alimenta.bem.modules.role.useCases.create.useCase;

public class RoleCreateUseCase
{
    private Localizer _localizer;
    public IRoleData _role_data;
    public RoleCreateUseCase(AlimentaBemContext context, Localizer localizer)
    {
        _role_data = new RoleData(context);
        _localizer = localizer;
    }

    public async Task<Role> exec(Role role)
    {
        var create_role = await _role_data.Create(role);

        if (create_role is null) throw new Exception(_localizer["role:RoleCreationFailed"]);

        return create_role;
    }
}