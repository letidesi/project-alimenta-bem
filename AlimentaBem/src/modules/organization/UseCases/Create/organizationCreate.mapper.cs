using alimenta_bem.helpers;
using alimenta_bem.src.organization.@enum;
using alimenta_bem.src.organization.repository;
using alimenta_bem.src.modules.organization.useCases.create.dto.request;
using alimenta_bem.src.modules.organization.useCases.create.dto.response;

namespace alimenta.bem.src.modules.organization.useCases.create.mapper;

public class OrganizationCreateMapper : Mapper<OrganizationCreateRequest, OrganizationCreateResponse, Organization>
{

    public override Organization ToEntity(OrganizationCreateRequest req) => new()
    {
        name = req.name,
        type = EnumHelper.ToEnumOrNull<TypeOrganization>(req.type),
        description = req.description
    };

    public override OrganizationCreateResponse FromEntity(Organization o) => new()
    {
        id = o.id,
        name = o.name,
        type = o.type.ToString(),
        description = o.description,
        createdAt = o.createdAt,
        updatedAt = o.updatedAt
    };
}