namespace alimenta_bem.src.natural.person.repository;

public interface INaturalPersonData
{
    Task<NaturalPerson> Create(NaturalPerson naturalPerson);
    Task<bool> CheckNaturalPersonAlreadyExistsWithSameUser(NaturalPerson naturalPerson);
}