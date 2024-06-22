using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta_bem.src.modules.user.useCases.authenticate.mapper;
using alimenta_bem.src.modules.user.useCases.authenticate.dto.request;
using alimenta_bem.src.modules.user.useCases.authenticate.dto.response;
using alimenta_bem.src.modules.user.useCases.authenticate.UseCase;

namespace alimenta_bem.src.modules.user.useCases.authenticate.endPoint;

public class UserAuthenticateEndPoint : Endpoint<UserAuthenticateRequest, UserAuthenticateResponse, UserAuthenticateMapper>
{
    public AlimentaBemContext _context { get; init; }
    public Localizer _localizer { get; init; }

    public override void Configure()
    {
        Post("user/authenticate");
        Options(u => u.WithTags("user"));
        Summary(s =>
        {
            s.Summary = "Create a new user";
            s.Description = "Register a user on the platform";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(UserAuthenticateRequest req, CancellationToken ct)
    {
        try
        {
            var userCreateUseCase = new UserAuthenticateUseCase(_context, _localizer);

            var authenticate_user = await userCreateUseCase.exec(req);

            var authenticated_user = Map.FromEntity(authenticate_user);

            await SendAsync(authenticated_user);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}