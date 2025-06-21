using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta_bem.src.modules.user.useCases.readOne.request;
using alimenta_bem.src.modules.user.useCases.readOne.response;
using alimenta_bem.src.modules.user.useCases.readOne.useCase;
using alimenta_bem.src.modules.user.useCases.readOne.mapper;

namespace alimenta_bem.src.modules.user.useCases.readOne.endPoint;

public class UserReadOneEndPoint : Endpoint<UserReadOneRequest, UserReadOneResponse, UserReadOneMapper>
{
    public AlimentaBemContext _context { get; init; }
    public Localizer _localizer { get; init; }

    public override void Configure()
    {
        Get("user/{userId}");
        Options(u => u.WithTags("user"));
        Summary(s =>
        {
            s.Summary = "Read auser";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(UserReadOneRequest req, CancellationToken ct)
    {
        try
        {
            var userReadOneUseCase = new UserReadOneUseCase(_context, _localizer);

            var user = Map.ToEntity(req);

            var readOneUser = await userReadOneUseCase.exec(user.id);

            var readOnedUser = Map.FromEntity(readOneUser);

            await SendAsync(readOnedUser);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}