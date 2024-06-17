using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace alimenta.bem.helpers;

public static class CultureInfoConfig
{
    public static void Configure(IServiceCollection services)
    {
        var supportedCultures = new CultureInfo[] { new("en-US"), new("pt-BR") };
        
        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture("en-US");
            options.SupportedCultures = supportedCultures;
        });

        services.AddLocalization(options => options.ResourcesPath = "languages");
    }
}
