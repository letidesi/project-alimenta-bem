using alimenta.bem.helpers;
using alimenta.bem.user.repository;
using alimenta.bem.modules.user.useCases.create.dto.request;
using alimenta.bem.modules.user.useCases.create.dto.response;

namespace alimenta.bem.modules.user.useCases.create.mapper;

public class UserCreateMapper : Mapper<UserCreateRequest, UserCreateResponse, User>
{

    public override User ToEntity(UserCreateRequest req) => new()
    {
        Name = req.Name.Trim(),
        Email = req.Email.ToLower().Trim(),
        PasswordHash = FormatPassword.GenerateHash(req.Password),
    };

    public override UserCreateResponse FromEntity(User u) => new()
    {
        Id = u.Id,
        Name = u.Name,
        Email = u.Email,
        CreatedAt = u.CreatedAt,
        UpdatedAt = u.UpdatedAt
    };
}