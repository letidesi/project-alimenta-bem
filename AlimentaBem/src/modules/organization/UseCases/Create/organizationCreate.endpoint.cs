using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta.bem.src.modules.organization.useCases.create.mapper;
using alimenta_bem.src.modules.organization.useCases.create.dto.request;
using alimenta_bem.src.modules.organization.useCases.create.dto.response;
using alimenta_bem.src.modules.organization.useCases.create.useCase;

namespace alimenta_bem.src.modules.organization.useCases.create.endpoint;

public class OrganizationEndPoint : Endpoint<OrganizationCreateRequest, OrganizationCreateResponse, OrganizationCreateMapper>
{
    public AlimentaBemContext _context { get; init; }
    public Localizer _localizer { get; init; }

    public override void Configure()
    {
        Post("organization");
        Options(n => n.WithTags("organization"));
        Summary(s =>
        {
            s.Summary = "Create a new organization";
            s.Description = "Register a organization on the platform";
        });
        AllowAnonymous(); 
    }

    public override async Task HandleAsync(OrganizationCreateRequest req, CancellationToken ct)
    {
        try
        {
            var organizationCreateUseCase = new OrganizationCreateUseCase(_context, _localizer);

            var organization = Map.ToEntity(req);

            var createOrganization = await organizationCreateUseCase.exec(organization);

            var createdOrganization = Map.FromEntity(createOrganization);

            await SendAsync(createdOrganization);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}