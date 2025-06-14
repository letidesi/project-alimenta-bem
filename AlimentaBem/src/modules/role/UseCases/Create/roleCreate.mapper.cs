using alimenta_bem.src.modules.role.repository;
using alimenta_bem.src.modules.role.useCases.create.dto.request;
using alimenta_bem.src.modules.role.useCases.create.dto.response;

namespace alimenta_bem.src.modules.role.useCases.create.mapper;

public class RoleCreateMapper : Mapper<RoleCreateRequest, RoleCreateResponse, Role>
{

    public override Role ToEntity(RoleCreateRequest req) => new()
    {
        userId = req.userId,
        type = req.type
    };

    public override RoleCreateResponse FromEntity(Role r) => new()
    {
        id = r.id,
        userId = r.userId,
        type = r.type,
        createdAt = r.createdAt,
        updatedAt = r.updatedAt
    };
}