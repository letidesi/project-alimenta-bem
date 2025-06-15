using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta.bem.src.modules.naturalPerson.useCases.readList.mapper;
using alimenta_bem.src.modules.naturalPerson.useCases.readList.dto.response;
using alimenta_bem.src.modules.naturalPerson.useCases.readList.useCase;

namespace alimenta_bem.src.modules.naturalPerson.useCases.readList.endpoint;

public class naturalPersonReadListEndpoint : EndpointWithoutRequest<NaturalPersonReadListResponse, NaturalPersonReadListMapper>
{
    public AlimentaBemContext _context { get; init; }
    public Localizer _localizer { get; init; }

    public override void Configure()
    {
        Get("natural-persons");
        Options(n => n.WithTags("naturalPerson"));
        Summary(s =>
        {
            s.Summary = "Get a list of naturalPersons";
            s.Description = "Retrieve a list of naturalPersons from the platform";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            var naturalPersonReadListUseCase = new NaturalPersonReadListUseCase(_context, _localizer);

            var naturalPersons = await naturalPersonReadListUseCase.exec();

            var response = Map.FromEntity(naturalPersons);

            await SendAsync(response);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}