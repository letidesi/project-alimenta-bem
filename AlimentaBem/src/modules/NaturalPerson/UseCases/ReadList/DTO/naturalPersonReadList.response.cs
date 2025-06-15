namespace alimenta_bem.src.modules.naturalPerson.useCases.readList.dto.response;

public class NaturalPersonReadListResponse
{
    public List<NaturalPersonReadListItem> naturalPersons { get; set; }

    public class NaturalPersonReadListItem
    {
        public Guid id { get; set; }
        public string name { get; set; }
    }
}