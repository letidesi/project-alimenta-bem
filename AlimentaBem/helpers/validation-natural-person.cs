using alimenta_bem.db.context;
using alimenta_bem.src.natural.person.repository;

namespace alimenta_bem.helpers;

public class ValidateNaturalPersonData
{
    private readonly AlimentaBemContext _context;
    private readonly Localizer _localizer;
    private readonly NaturalPersonData _natural_person_data;

    public ValidateNaturalPersonData(AlimentaBemContext context, Localizer localizer)
    {
        _context = context;
        _localizer = localizer;
        _natural_person_data = new NaturalPersonData(_context);
    }
    public void Validate_Natural_Person_Fields(NaturalPerson naturalPerson)
    {
        naturalPerson.firstName = naturalPerson.firstName.Trim();
        naturalPerson.lastName = naturalPerson.lastName.Trim();

        Validate_Date_Of_Birth(naturalPerson.birthdayDate);

        if (naturalPerson.socialName is not null)
            naturalPerson.socialName = naturalPerson.socialName.Trim();
    }
    public async Task Exist_Data_Of_Natural_Person(NaturalPerson naturalPerson)
    {
        var existingNaturalPerson = await _natural_person_data.Check_Natural_Person_Already_Exists_With_Same_User(naturalPerson);
        if (existingNaturalPerson)
            throw new Exception(_localizer["naturalPerson:NaturalPersonSameUserId"]);
    }

    public bool Is_Valid_Cpf(string cpf)
    {
        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        if (cpf.Length != 11)
            return false;

        if (cpf.All(c => c == cpf[0]))
            return false;

        int[] pesosDigito1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] pesosDigito2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        int soma1 = cpf.Zip(pesosDigito1, (c, p) => (c - '0') * p).Sum();
        int resto1 = soma1 % 11;
        int digito1 = resto1 < 2 ? 0 : 11 - resto1;

        int soma2 = cpf.Zip(pesosDigito2, (c, p) => (c - '0') * p).Sum();
        int resto2 = soma2 % 11;
        int digito2 = resto2 < 2 ? 0 : 11 - resto2;

        return cpf[9] - '0' == digito1 && cpf[10] - '0' == digito2;
    }
    public DateOnly? Validate_Date_Of_Birth(DateOnly? birthdayDate)
    {
        if (birthdayDate.HasValue)
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

            if (birthdayDate > currentDate)
                throw new Exception(_localizer["naturalPerson:DateOfBirthInvalid"]);
        }

        return birthdayDate;
    }
}