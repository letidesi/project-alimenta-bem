using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta_bem.src.modules.naturalPerson.useCases.readOne.request;
using alimenta_bem.src.modules.naturalPerson.useCases.readOne.response;
using alimenta_bem.src.modules.naturalPerson.useCases.readOne.useCase;
using alimenta_bem.src.modules.naturalPerson.useCases.readOne.mapper;

namespace alimenta_bem.src.modules.naturalPerson.useCases.readOne.endPoint;

public class NaturalPersonReadOneEndPoint : Endpoint<NaturalPersonReadOneRequest, NaturalPersonReadOneResponse, NaturalPersonReadOneMapper>
{
    public AlimentaBemContext _context { get; init; }
    public Localizer _localizer { get; init; }

    public override void Configure()
    {
        Get("natural-person/{userId}");
        Options(u => u.WithTags("naturalPerson"));
        Summary(s =>
        {
            s.Summary = "Read a naturalPerson";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(NaturalPersonReadOneRequest req, CancellationToken ct)
    {
        try
        {
            var naturalPersonReadOneUseCase = new NaturalPersonReadOneUseCase(_context, _localizer);

            var naturalPerson = Map.ToEntity(req);

            var readOneNaturalPerson = await naturalPersonReadOneUseCase.exec(naturalPerson.id);

            var readOnedNaturalPerson = Map.FromEntity(readOneNaturalPerson);

            await SendAsync(readOnedNaturalPerson);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}