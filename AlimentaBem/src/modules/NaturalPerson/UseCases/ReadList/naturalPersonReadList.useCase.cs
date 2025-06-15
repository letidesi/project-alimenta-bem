using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta_bem.src.modules.user.repository;
using alimenta_bem.src.natural.person.repository;

namespace alimenta_bem.src.modules.naturalPerson.useCases.readList.useCase;

public class NaturalPersonReadListUseCase
{
    private Localizer _localizer;
    public IUserData _userData;
    public INaturalPersonData _naturalPersonData;

    public NaturalPersonReadListUseCase(AlimentaBemContext context, Localizer localizer)
    {
        _localizer = localizer;
        _naturalPersonData = new NaturalPersonData(context);
    }

    public async Task<List<NaturalPerson>> exec()
    {

        var naturalPersons = await _naturalPersonData.ReadList();
        if (naturalPersons.Count == 0)
            throw new Exception(_localizer["naturalPerson:UserNotFound"]);

        return naturalPersons;
    }
}