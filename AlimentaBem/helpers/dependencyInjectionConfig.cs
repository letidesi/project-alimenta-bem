using alimenta_bem.helpers;
using alimenta_bem.src.providers.crypto;

public static class DependencyInjectionConfig
{
    public static void Register_Services(IServiceCollection services)
    {
        services.AddSingleton<Localizer>();
        services.AddSingleton<ICryptoProvider, CryptoService>();
        services.AddSingleton<CryptoService>();

    }
}
