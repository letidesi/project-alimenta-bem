using alimenta.bem.helpers;
using alimenta.bem.providers;

public static class DependencyInjectionConfig
{
    public static void Register_Services(IServiceCollection services)
    {
        services.AddSingleton<Localizer>();
        services.AddSingleton<ICryptoProvider, CryptoService>();
    }
}
