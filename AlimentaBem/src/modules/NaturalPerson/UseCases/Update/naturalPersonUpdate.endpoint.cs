using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta.bem.src.modules.natural.person.useCases.update.mapper;
using alimenta_bem.src.modules.natural.person.useCases.update.dto.request;
using alimenta_bem.src.modules.natural.person.useCases.update.dto.response;
using alimenta_bem.src.modules.natural.person.useCases.update.useCase;

namespace alimenta_bem.src.modules.natural.person.useCases.update.endpoint;

public class NaturalPersonUpdateEndPoint : Endpoint<NaturalPersonUpdateRequest, NaturalPersonUpdateResponse, NaturalPersonUpdateMapper>
{
    public AlimentaBemContext _context { get; init; }
    public Localizer _localizer { get; init; }

    public override void Configure()
    {
        Put("natural-person");
        Options(n => n.WithTags("natural-person"));
        Summary(s =>
        {
            s.Summary = "Update a new natural person";
            s.Description = "Update a natural person on the platform";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(NaturalPersonUpdateRequest req, CancellationToken ct)
    {
        try
        {
            var naturalPersonUpdateUseCase = new NaturalPersonUpdateUseCase(_context, _localizer);

            var naturalPerson = Map.ToEntity(req);

            var updateNaturalPerson = await naturalPersonUpdateUseCase.exec(naturalPerson);

            var updatedNaturalPerson = Map.FromEntity(updateNaturalPerson);

            await SendAsync(updatedNaturalPerson);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}