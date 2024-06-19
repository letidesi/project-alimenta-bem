using NSwag;
using NJsonSchema;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace alimenta.bem.helpers;
public class PatchOperationProcessor : IOperationProcessor
{
    public bool Process(OperationProcessorContext context)
    {
        if (context.OperationDescription.Method != "patch") return true;

        const string example = "[ { \"path\": \"/a-path\",\"op\": \"replace\",\"value\": \"A replacement value\" },{ \"path\": \"/another-path\",\"op\": \"remove\" }]";

        context.OperationDescription.Operation.Parameters.Add(new OpenApiParameter
        {
            Kind = OpenApiParameterKind.Body,
            IsRequired = true,
            Schema = JsonSchema.CreateAnySchema(),
            Example = example
        });

        return true;
    }
}