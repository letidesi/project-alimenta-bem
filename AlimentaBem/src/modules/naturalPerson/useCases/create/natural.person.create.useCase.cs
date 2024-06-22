using alimenta.bem.helpers;
using alimenta.bem.db.context;
using alimenta.bem.natural.person.repository;

namespace alimenta.bem.modules.natural.person.useCases.create.useCase;

public class NaturalPersonCreateUseCase
{
    private Localizer _localizer;
    public INaturalPersonData _natural_person_data;
    private readonly ValidateNaturalPersonData _validateNaturalPersonData;
    public NaturalPersonCreateUseCase(AlimentaBemContext context, Localizer localizer)
    {
        _localizer = localizer;
        _natural_person_data = new NaturalPersonData(context);
        _validateNaturalPersonData = new ValidateNaturalPersonData(context, localizer);
    }

    public async Task<NaturalPerson> exec(NaturalPerson naturalPerson)
    {
        _validateNaturalPersonData.Validate_Natural_Person_Fields(naturalPerson);
        await _validateNaturalPersonData.Exist_Data_Of_Natural_Person(naturalPerson);

        var create_natural_person = await _natural_person_data.Create(naturalPerson);
        if (create_natural_person is null)
            throw new Exception(_localizer["natural.person:IndividualCreationFailed"]);

        return create_natural_person;
    }
}