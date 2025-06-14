using alimenta_bem.src.natural.person.repository;
using alimenta_bem.src.modules.natural.person.useCases.create.dto.request;
using alimenta_bem.src.modules.natural.person.useCases.create.dto.response;
using alimenta_bem.helpers;
using alimenta_bem.src.natural.person.@enum;

namespace alimenta.bem.src.modules.natural.person.useCases.create.mapper;

public class NaturalPersonCreateMapper : Mapper<NaturalPersonCreateRequest, NaturalPersonCreateResponse, NaturalPerson>
{

    public override NaturalPerson ToEntity(NaturalPersonCreateRequest req) => new()
    {
        userId = req.userId,
        firstName = req.firstName,
        lastName = req.lastName,
        socialName = req.socialName,
        age = req.age,
        birthdayDate = req.birthdayDate,
        gender = EnumHelper.ToEnumOrNull<Gender>(req.gender),
        skinColor = EnumHelper.ToEnumOrNull<SkinColor>(req.skinColor),
        isPcd = req.isPcd
    };

    public override NaturalPersonCreateResponse FromEntity(NaturalPerson n) => new()
    {
        id = n.id,
        userId = n.userId,
        firstName = n.firstName,
        lastName = n.lastName,
        socialName = n.socialName,
        age = n.age,
        birthdayDate = n.birthdayDate,
        gender = n.gender.ToString(),
        skinColor = n.skinColor.ToString(),
        isPcd = n.isPcd,
        createdAt = n.createdAt,
        updatedAt = n.updatedAt
    };
}