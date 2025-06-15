using alimenta_bem.src.organization.repository;
using alimenta_bem.src.modules.organization.useCases.readList.dto.response;

namespace alimenta.bem.src.modules.organization.useCases.readList.mapper;

public class OrganizationReadListMapper : ResponseMapper<OrganizationReadListResponse, List<Organization>>
{
    public override OrganizationReadListResponse FromEntity(List<Organization> list) => new()
    {
        organizations = list.Select(o => new OrganizationReadListResponse.OrganizationReadListItem()
        { 
            id = o.id,
            name = o.name
        }).ToList()
    };
}