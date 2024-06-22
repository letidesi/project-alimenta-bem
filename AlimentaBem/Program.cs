global using FastEndpoints;
global using FluentValidation;
global using Microsoft.EntityFrameworkCore;
using alimenta_bem.helpers;
using FastEndpoints.Security;
using alimenta_bem.db.context;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

public partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var isStaging = builder.Environment.IsStaging();

        var isDevelopment = builder.Environment.IsDevelopment();


        ConfigureServices(builder, isDevelopment);

        var app = builder.Build();

        ConfigureApp(app, isStaging, isDevelopment);

        app.Run();
    }

    public static void ConfigureServices(WebApplicationBuilder builder, bool isDevelopment)
    {

        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

        dotenv.net.DotEnv.Load();

        string connectionString = builder.Configuration.GetConnectionString("sqlConnection");
        builder.Services.AddDbContext<AlimentaBemContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddDbContext<AlimentaBemContext>(options =>

         options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

        #region External APIs

        builder.Services.AddHttpContextAccessor();

        if (isDevelopment)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost3000",

            builder => builder
              .WithOrigins("http://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()
          );
            });
        }

        #endregion

        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();

        // inject services
        DependencyInjectionConfig.Register_Services(builder.Services);
        CultureInfoConfig.Configure(builder.Services);

        builder.Services.AddControllers();
        builder.Services.AddFastEndpoints();

        // Console.WriteLine($"{builder.Environment.EnvironmentName}");
        var JWT_SECRET = builder.Configuration.GetSection("JWT_SECRET").Value!;

        builder.Services.AddAuthenticationJwtBearer(S => S.SigningKey = JWT_SECRET);

        builder.Services.AddSwaggerGen();
        builder.Services.AddSwaggerDocument(document =>
           {
               document.Title = "AlimentaBem";
               document.Version = "v1";
               document.OperationProcessors.Add(new PatchOperationProcessor());
               document.OperationProcessors.Add(new AcceptLanguageHeaderOperationProcessor(builder.Services.BuildServiceProvider().GetService<IOptions<RequestLocalizationOptions>>()));
           });
    }

    public static void ConfigureApp(WebApplication app, bool isStaging, bool isDevelopment)
    {
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseFastEndpoints(c => c.Serializer.Options.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        app.UseRequestLocalization();
        app.UseOpenApi();

        if (isStaging || isDevelopment)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

        }

        if (isDevelopment)
        {
            app.UseCors("AllowLocalhost3000");
        }

    }

}