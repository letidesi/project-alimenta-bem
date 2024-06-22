namespace alimenta.bem.natural.person.repository;

public interface INaturalPersonData
{
    Task<NaturalPerson> Create(NaturalPerson naturalPerson);
    Task<bool> Check_Natural_Person_Already_Exists_With_Same_User(NaturalPerson naturalPerson);
    Task<bool> Check_Rg_Already_Exists(Guid Id, string Rg);
    Task<bool> Check_Cpf_Already_Exists(Guid Id, string Cpf);
}