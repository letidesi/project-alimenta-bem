using alimenta_bem.src.modules.user.repository;

namespace alimenta_bem.src.natural.person.repository;

public interface INaturalPersonData
{
    Task<User?> GetUserByEmail(string email);
    Task<NaturalPerson> Create(NaturalPerson naturalPerson);
    Task<bool> CheckNaturalPersonAlreadyExistsWithSameUser(NaturalPerson naturalPerson);
}