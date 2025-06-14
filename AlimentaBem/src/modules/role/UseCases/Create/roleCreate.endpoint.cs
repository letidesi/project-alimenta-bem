using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta_bem.src.modules.role.useCases.create.mapper;
using alimenta_bem.src.modules.role.useCases.create.dto.request;
using alimenta_bem.src.modules.role.useCases.create.dto.response;
using alimenta_bem.src.modules.role.useCases.create.useCase;

namespace alimenta_bem.src.modules.role.useCases.create.endPoint;

public class RoleCreateEndPoint : Endpoint<RoleCreateRequest, RoleCreateResponse, RoleCreateMapper>
{
    public AlimentaBemContext _context { get; init; }
    public Localizer _localizer { get; init; }

    public override void Configure()
    {
        Post("role");
        Options(u => u.WithTags("role"));
        Summary(s =>
        {
            s.Summary = "Create a new role";
            s.Description = "Register a role on the platform";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(RoleCreateRequest req, CancellationToken ct)
    {
        try
        {
            var roleCreateUseCase = new RoleCreateUseCase(_context, _localizer);

            var role = Map.ToEntity(req);

            var createRole = await roleCreateUseCase.exec(role);

            var createdRole = Map.FromEntity(createRole);

            await SendAsync(createdRole);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}