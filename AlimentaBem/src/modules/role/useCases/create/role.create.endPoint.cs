using alimenta.bem.helpers;
using alimenta.bem.db.context;
using alimenta.bem.modules.role.useCases.create.mapper;
using alimenta.bem.modules.role.useCases.create.dto.request;
using alimenta.bem.modules.role.useCases.create.dto.response;
using alimenta.bem.modules.role.useCases.create.useCase;

namespace alimenta.bem.modules.role.useCases.create.endpoint;

public class RoleCreateEndPoint : Endpoint<RoleCreateRequest, RoleCreateResponse, RoleCreateMapper>
{
    public AlimentaBemContext _context { get; init; }
    public Localizer _localizer { get; init; }

    public override void Configure()
    {
        Post("role");
        Options(u => u.WithTags("role"));
        Roles("Admin, Developer");
        Summary(s =>
        {
            s.Summary = "Create a new role";
            s.Description = "Register a role on the platform";
        });
    }

    public override async Task HandleAsync(RoleCreateRequest req, CancellationToken ct)
    {
        try
        {
            var roleCreateUseCase = new RoleCreateUseCase(_context, _localizer);

            var role = Map.ToEntity(req);

            var create_role = await roleCreateUseCase.exec(role);

            var created_role = Map.FromEntity(create_role);

            await SendAsync(created_role);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}