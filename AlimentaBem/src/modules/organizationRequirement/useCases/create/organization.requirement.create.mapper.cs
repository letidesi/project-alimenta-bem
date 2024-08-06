using alimenta_bem.helpers;
using alimenta_bem.src.organization.requirement.@enum;
using alimenta_bem.src.organization.requirement.repository;
using alimenta_bem.src.modules.organization.requirement.useCases.create.dto.request;
using alimenta_bem.src.modules.organization.requirement.useCases.create.dto.response;

namespace alimenta.bem.src.modules.organization.requirement.useCases.create.mapper;

public class OrganizationRequirementCreateMapper : Mapper<OrganizationRequirementCreateRequest, OrganizationRequirementCreateResponse, OrganizationRequirement>
{

    public override OrganizationRequirement ToEntity(OrganizationRequirementCreateRequest req) => new()
    {
        organizationId = req.organizationId,
        itemName = req.itemName,
        quantity = req.quantity,
        type = EnumHelper.ToEnum<Priority>(req.type),
    };

    public override OrganizationRequirementCreateResponse FromEntity(OrganizationRequirement o) => new()
    {
        id = o.id,
        itemName = o.itemName,
        quantity = o.quantity,
        type = o.type.ToString(),
        createdAt = o.createdAt,
        updatedAt = o.updatedAt
    };
}