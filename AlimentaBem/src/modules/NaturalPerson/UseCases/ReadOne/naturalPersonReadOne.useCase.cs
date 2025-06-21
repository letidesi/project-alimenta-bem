using alimenta_bem.db.context;
using alimenta_bem.helpers;
using alimenta_bem.src.natural.person.repository;

namespace alimenta_bem.src.modules.naturalPerson.useCases.readOne.useCase;

public class NaturalPersonReadOneUseCase
{
    private Localizer _localizer;
    public INaturalPersonData _naturalPersonData;
    public NaturalPersonReadOneUseCase(AlimentaBemContext context, Localizer localizer)
    {
        _naturalPersonData = new NaturalPersonData(context);
        _localizer = localizer;
    }

    public async Task<NaturalPerson> exec(Guid naturalPersonId)
    {
        var naturalPerson = await _naturalPersonData.ReadNaturalPersonByUser(naturalPersonId);
        if (naturalPerson is null)
            throw new Exception(_localizer["naturalPerson:NotFoundNaturalPerson"]);

        return naturalPerson;
    }
}