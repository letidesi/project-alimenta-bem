using alimenta_bem.helpers;
using alimenta_bem.src.modules.user.useCases.create.dto.request;
using alimenta_bem.src.modules.user.useCases.create.dto.response;
using alimenta_bem.src.modules.user.repository;

namespace alimenta_bem.src.modules.user.useCases.create.mapper;

public class UserCreateMapper : Mapper<UserCreateRequest, UserCreateResponse, User>
{

    public override User ToEntity(UserCreateRequest req) => new()
    {
        name = req.name.Trim(),
        email = req.email.ToLower().Trim(),
        passwordHash = FormatPassword.GenerateHash(req.password),
    };

    public override UserCreateResponse FromEntity(User u) => new()
    {
        id = u.id,
        name = u.name,
        email = u.email,
        createdAt = u.createdAt,
        updatedAt = u.updatedAt
    };
}