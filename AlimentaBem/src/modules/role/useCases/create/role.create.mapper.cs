using alimenta_bem.src.modules.role.repository;
using alimenta_bem.src.modules.role.useCases.create.dto.request;
using alimenta_bem.src.modules.role.useCases.create.dto.response;

namespace alimenta_bem.src.modules.role.useCases.create.mapper;

public class RoleCreateMapper : Mapper<RoleCreateRequest, RoleCreateResponse, Role>
{

    public override Role ToEntity(RoleCreateRequest req) => new()
    {
        UserId = req.UserId,
        Type = req.Type
    };

    public override RoleCreateResponse FromEntity(Role r) => new()
    {
        Id = r.Id,
        UserId = r.UserId,
        Type = r.Type,
        CreatedAt = r.CreatedAt,
        UpdatedAt = r.UpdatedAt
    };
}