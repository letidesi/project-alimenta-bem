global using FastEndpoints;
global using FluentValidation;
global using Microsoft.EntityFrameworkCore;
using alimenta_bem.helpers;
using alimenta_bem.db.context;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Cryptography;
using System.Security.Claims;

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
    dotenv.net.DotEnv.Load();

    string connectionString = builder.Configuration.GetConnectionString("sqlConnection");

    builder.Services.AddDbContext<AlimentaBemContext>(options =>
        options.UseSqlServer(connectionString));

    builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

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

   
    var publicKeyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "public.key");
    var publicKeyText = File.ReadAllText(publicKeyPath);

    var rsa = RSA.Create();
    rsa.ImportFromPem(publicKeyText.ToCharArray());

    var rsaSecurityKey = new RsaSecurityKey(rsa);

    // Configurar autenticação e autorização
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = "Alimentabem",
                ValidAudience = "ABem",

                IssuerSigningKey = rsaSecurityKey,

                RoleClaimType = ClaimTypes.Role
            };
        });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    });

    // Outros serviços
    DependencyInjectionConfig.Register_Services(builder.Services);
    CultureInfoConfig.Configure(builder.Services);

    builder.Services.AddFastEndpoints();

    var JWT_SECRET = builder.Configuration.GetSection("JWT_SECRET").Value!;

    builder.Services.AddControllers();
    builder.Services.AddFastEndpoints();

    builder.Services.AddEndpointsApiExplorer();
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
        if (isDevelopment)
        {
            app.UseCors("AllowLocalhost3000");
        }
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


    }

}