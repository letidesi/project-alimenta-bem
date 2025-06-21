using alimenta_bem.src.natural.person.repository;
using alimenta_bem.src.modules.naturalPerson.useCases.readOne.request;
using alimenta_bem.src.modules.naturalPerson.useCases.readOne.response;

namespace alimenta_bem.src.modules.naturalPerson.useCases.readOne.mapper;

public class NaturalPersonReadOneMapper : Mapper<NaturalPersonReadOneRequest, NaturalPersonReadOneResponse, NaturalPerson>
{

    public override NaturalPerson ToEntity(NaturalPersonReadOneRequest req) => new()
    {
        id = req.userId,
    };

    public override NaturalPersonReadOneResponse FromEntity(NaturalPerson n) => new()
    {
        naturalPersonId = n.id,
        name = n.name,
        email = n.emailUser,
        socialName = n.socialName,
        userId = n.userId,
        age = n.age,
        birthdayDate = n.birthdayDate,
        skinColor = n.skinColor.ToString(),
        gender = n.gender.ToString(),
        isPcd = n.isPcd
    };
}