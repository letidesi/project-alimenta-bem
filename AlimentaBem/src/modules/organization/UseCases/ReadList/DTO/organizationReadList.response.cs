namespace alimenta_bem.src.modules.organization.useCases.readList.dto.response;

public class OrganizationReadListResponse
{
    public List<OrganizationReadListItem> organizations { get; set; }

    public class OrganizationReadListItem
    {
        public Guid id { get; set; }
        public string name { get; set; }
    }
}