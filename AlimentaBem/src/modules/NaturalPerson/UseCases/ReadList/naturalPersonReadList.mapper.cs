using alimenta_bem.src.modules.naturalPerson.useCases.readList.dto.response;
using alimenta_bem.src.natural.person.repository;

namespace alimenta.bem.src.modules.naturalPerson.useCases.readList.mapper;

public class NaturalPersonReadListMapper : ResponseMapper<NaturalPersonReadListResponse, List<NaturalPerson>>
{
    public override NaturalPersonReadListResponse FromEntity(List<NaturalPerson> list) => new()
    {
        naturalPersons = list.Select(n => new NaturalPersonReadListResponse.NaturalPersonReadListItem()
        {
            id = n.id,
            name = n.name
        }).ToList()
    };
}