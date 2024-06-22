using alimenta.bem.natural.person.repository;
using alimenta.bem.modules.natural.person.useCases.create.dto.request;
using alimenta.bem.modules.natural.person.useCases.create.dto.response;

namespace alimenta.bem.modules.natural.person.useCases.create.mapper;

public class UserCreateMapper : Mapper<NaturalPersonCreateRequest, NaturalPersonCreateResponse, NaturalPerson>
{

    public override NaturalPerson ToEntity(NaturalPersonCreateRequest req) => new()
    {
        UserId = req.UserId,
        FirstName = req.FirstName,
        LastName = req.LastName,
        SocialName = req.SocialName,
        Cpf = req.Cpf,
        Rg = req.Rg,
        Age = req.Age,
        BirthdayDate = req.BirthdayDate,
        Gender = req.Gender,
        SkinColor = req.SkinColor,
        IsPcd = req.IsPcd
    };

    public override NaturalPersonCreateResponse FromEntity(NaturalPerson n) => new()
    {
        Id = n.Id,
        UserId = n.UserId,
        FirstName = n.FirstName,
        LastName = n.LastName,
        SocialName = n.SocialName,
        Cpf = n.Cpf,
        Rg = n.Rg,
        Age = n.Age,
        BirthdayDate = n.BirthdayDate,
        Gender = n.Gender,
        SkinColor = n.SkinColor,
        IsPcd = n.IsPcd,
        CreatedAt = n.CreatedAt,
        UpdatedAt = n.UpdatedAt
    };
}