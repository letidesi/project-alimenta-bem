using alimenta_bem.src.natural.person.repository;
using alimenta_bem.src.modules.natural.person.useCases.update.dto.request;
using alimenta_bem.src.modules.natural.person.useCases.update.dto.response;
using alimenta_bem.helpers;
using alimenta_bem.src.natural.person.@enum;

namespace alimenta.bem.src.modules.natural.person.useCases.update.mapper;

public class NaturalPersonUpdateMapper : Mapper<NaturalPersonUpdateRequest, NaturalPersonUpdateResponse, NaturalPerson>
{

    public override NaturalPerson ToEntity(NaturalPersonUpdateRequest req) => new()
    {
        userId = req.userId,
        emailUser = req.email,
        name = req.name,
        socialName = req.socialName,
        age = req.age,
        birthdayDate = req.birthdayDate,
        gender = EnumHelper.ToEnumOrNull<Gender>(req.gender),
        skinColor = EnumHelper.ToEnumOrNull<SkinColor>(req.skinColor),
        isPcd = req.isPcd
    };

    public override NaturalPersonUpdateResponse FromEntity(NaturalPerson n) => new()
    {
        id = n.id,
        emailUser = n.emailUser,
        name = n.name,
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