using alimenta.bem.helpers;

public static class DependencyInjectionConfig
{
    public static void Register_Services(IServiceCollection services)
    {
        services.AddSingleton<Localizer>();
    }
}
