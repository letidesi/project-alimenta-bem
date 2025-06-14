using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta.bem.src.modules.natural.person.useCases.create.mapper;
using alimenta_bem.src.modules.natural.person.useCases.create.dto.request;
using alimenta_bem.src.modules.natural.person.useCases.create.dto.response;
using alimenta_bem.src.modules.natural.person.useCases.create.useCase;

namespace alimenta_bem.src.modules.natural.person.useCases.create.endpoint;

public class NaturalPersonCreateEndPoint : Endpoint<NaturalPersonCreateRequest, NaturalPersonCreateResponse, NaturalPersonCreateMapper>
{
    public AlimentaBemContext _context { get; init; }
    public Localizer _localizer { get; init; }

    public override void Configure()
    {
        Post("natural-person");
        Options(n => n.WithTags("natural-person"));
        Summary(s =>
        {
            s.Summary = "Create a new natural person";
            s.Description = "Register a natural person on the platform";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(NaturalPersonCreateRequest req, CancellationToken ct)
    {
        try
        {
            var naturalPersonCreateUseCase = new NaturalPersonCreateUseCase(_context, _localizer);

            var naturalPerson = Map.ToEntity(req);

            var createNaturalPerson = await naturalPersonCreateUseCase.exec(naturalPerson);

            var createdNaturalPerson = Map.FromEntity(createNaturalPerson);

            await SendAsync(createdNaturalPerson);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}