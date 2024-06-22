using alimenta.bem.helpers;
using alimenta.bem.db.context;
using alimenta.bem.modules.natural.person.useCases.create.mapper;
using alimenta.bem.modules.natural.person.useCases.create.dto.request;
using alimenta.bem.modules.natural.person.useCases.create.dto.response;
using alimenta.bem.modules.natural.person.useCases.create.useCase;

namespace alimenta.bem.modules.natural.person.useCases.create.endpoint;

public class UserCreateEndPoint : Endpoint<NaturalPersonCreateRequest, NaturalPersonCreateResponse, UserCreateMapper>
{
    public AlimentaBemContext _context { get; init; }
    public Localizer _localizer { get; init; }

    public override void Configure()
    {
        Post("natural-person");
        Options(u => u.WithTags("natural-person"));
        Summary(s =>
        {
            s.Summary = "Create a new natural person";
            s.Description = "Register a natural person on the platform";
        });
    }

    public override async Task HandleAsync(NaturalPersonCreateRequest req, CancellationToken ct)
    {
        try
        {
            var naturalPersonCreateUseCase = new NaturalPersonCreateUseCase(_context, _localizer);

            var natural_person = Map.ToEntity(req);

            var create_natural_person = await naturalPersonCreateUseCase.exec(natural_person);

            var created_natural_person = Map.FromEntity(create_natural_person);

            await SendAsync(created_natural_person);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}