using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta_bem.src.modules.user.repository;
using alimenta_bem.src.natural.person.repository;

namespace alimenta_bem.src.modules.natural.person.useCases.create.useCase;

public class NaturalPersonCreateUseCase
{
    private Localizer _localizer;
    public IUserData _userData;
    public INaturalPersonData _naturalPersonData;
    private readonly ValidateNaturalPersonData _validateNaturalPersonData;
    public NaturalPersonCreateUseCase(AlimentaBemContext context, Localizer localizer)
    {
        _localizer = localizer;
        _naturalPersonData = new NaturalPersonData(context);
        _validateNaturalPersonData = new ValidateNaturalPersonData(context, localizer);
    }

    public async Task<NaturalPerson> exec(NaturalPerson naturalPerson)
    {
        _validateNaturalPersonData.ValidateNaturalPersonFields(naturalPerson);
        await _validateNaturalPersonData.ExistDataOfNaturalPerson(naturalPerson);

        var user = await _naturalPersonData.GetUserByEmail(naturalPerson.emailUser);
        if (user is null)
            throw new Exception(_localizer["naturalPerson:UserNotFound"]);

        naturalPerson.userId = user.id;
        naturalPerson.user = user;

        var createNaturalPerson = await _naturalPersonData.Create(naturalPerson);
        if (createNaturalPerson is null)
            throw new Exception(_localizer["naturalPerson:IndividualCreationFailed"]);

        return createNaturalPerson;
    }
}