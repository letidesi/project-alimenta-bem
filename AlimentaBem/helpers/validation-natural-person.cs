using alimenta.bem.db.context;
using alimenta.bem.natural.person.repository;

namespace alimenta.bem.helpers;

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
        naturalPerson.FirstName = naturalPerson.FirstName.Trim();
        naturalPerson.LastName = naturalPerson.LastName.Trim();

        var validCPF = Is_Valid_Cpf(naturalPerson.Cpf);
        if (!validCPF) throw new Exception(_localizer["naturalPerson:CPFInvalid"]);

        Validate_Date_Of_Birth(naturalPerson.BirthdayDate);

        naturalPerson.Cpf = StringUtility.RemoveSpecialCharacter(naturalPerson.Cpf).Trim();
        if (naturalPerson.Cpf is null)
            throw new Exception(_localizer["naturalPerson:CPFRequired"]);
        if (naturalPerson.Cpf.Length != 11)
            throw new Exception(_localizer["naturalPerson:CPFSizeRequired"]);

        if (naturalPerson.SocialName is not null)
            naturalPerson.SocialName = naturalPerson.SocialName.Trim();
    }
    public async Task Exist_Data_Of_Natural_Person(NaturalPerson naturalPerson)
    {
        var existingNaturalPerson = await _natural_person_data.Check_Natural_Person_Already_Exists_With_Same_User(naturalPerson);
        if (existingNaturalPerson)
            throw new Exception(_localizer["naturalPerson:NaturalPersonSameUserId"]);

        if (naturalPerson.Rg is not null)
        {
            var existRG = await _natural_person_data.Check_Rg_Already_Exists(naturalPerson.Id, naturalPerson.Rg);
            if (existRG) throw new Exception(_localizer["naturalPerson:RGAlreadyUse"]);
        }

        var existCPF = await _natural_person_data.Check_Cpf_Already_Exists(naturalPerson.Id, naturalPerson.Cpf);
        if (existCPF) throw new Exception(_localizer["naturalPerson:CPFAlreadyUse"]);
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