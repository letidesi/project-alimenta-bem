using alimenta.bem.helpers;
using alimenta.bem.db.context;
using alimenta.bem.modules.user.useCases.create.mapper;
using alimenta.bem.modules.user.useCases.create.dto.request;
using alimenta.bem.modules.user.useCases.create.dto.response;
using alimenta.bem.modules.user.useCases.create.useCase;

namespace alimenta.bem.modules.user.useCases.create.endpoint;

public class UserCreateEndPoint : Endpoint<UserCreateRequest, UserCreateResponse, UserCreateMapper>
{
    public AlimentaBemContext _context { get; init; }
    public Localizer _localizer { get; init; }

    public override void Configure()
    {
        Post("user");
        Options(u => u.WithTags("user"));
        Summary(s =>
        {
            s.Summary = "Create a new user";
            s.Description = "Register a user on the platform";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(UserCreateRequest req, CancellationToken ct)
    {
        try
        {
            var userCreateUseCase = new UserCreateUseCase(_context, _localizer);

            var user = Map.ToEntity(req);

            var create_user = await userCreateUseCase.exec(user);

            var created_user = Map.FromEntity(create_user);

            await SendAsync(created_user);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}