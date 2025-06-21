using alimenta_bem.src.modules.user.repository;

namespace alimenta_bem.src.natural.person.repository;

public interface INaturalPersonData
{
    Task<User?> GetUserByEmail(string email);
    Task<NaturalPerson> Create(NaturalPerson naturalPerson);
    Task<NaturalPerson> Update(NaturalPerson naturalPerson);
    Task<List<NaturalPerson>> ReadList();
    Task<NaturalPerson> ReadNaturalPersonByUser(Guid userId);
    Task<NaturalPerson> CheckNaturalPersonAlreadyExist(NaturalPerson naturalPerson);
}