
using NSwag;
using NSwag.Generation.Processors;
using Microsoft.Extensions.Options;
using NSwag.Generation.Processors.Contexts;

namespace alimenta.bem.helpers;

public class AcceptLanguageHeaderOperationProcessor : IOperationProcessor
{

    private readonly List<string>? _supportedLanguages;

    public AcceptLanguageHeaderOperationProcessor(IOptions<RequestLocalizationOptions> requestLocalizationOptions)
    {
        _supportedLanguages = 
            requestLocalizationOptions
                .Value
                .SupportedCultures?
                .Select(c => c.TwoLetterISOLanguageName)
                .ToList();
    }

    public bool Process(OperationProcessorContext context)
    {
        var parameter = new OpenApiParameter
        {
            Name = "accept-language",
            Kind = OpenApiParameterKind.Header,
            Description = "Language preference for the response.",
            IsRequired = false,
            Schema = new NJsonSchema.JsonSchema()
            {
                Type = NJsonSchema.JsonObjectType.String,
                Item = new NJsonSchema.JsonSchema() { 
                    Type = NJsonSchema.JsonObjectType.String
                }
            }
        };

        _supportedLanguages.ForEach(l => parameter.Schema.EnumerationNames.Add(l));

        context.OperationDescription.Operation.Parameters.Add(parameter);
        
        return true;
    }
}