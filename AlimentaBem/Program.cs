global using FastEndpoints;
global using FluentValidation;
global using Microsoft.EntityFrameworkCore;
using alimenta.bem.helpers;
using FastEndpoints.Security;
using alimenta.bem.db.context;
using System.Text.Json.Serialization;

public partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<AlimentaBemContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();

        DependencyInjectionConfig.Register_Services(builder.Services);
        CultureInfoConfig.Configure(builder.Services);

        builder.Services.AddControllers();
        builder.Services.AddFastEndpoints();

        builder.Services.AddSwaggerGen();

        //Verify enviroment name Console.WriteLine($"{builder.Environment.EnvironmentName}");
        var JWT_SECRET = builder.Configuration.GetSection("JWT_SECRET").Value!;

        builder.Services.AddAuthenticationJwtBearer(S => S.SigningKey = JWT_SECRET);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        app.UseFastEndpoints(c => c.Serializer.Options.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        app.MapControllers();
        app.UseOpenApi();

        app.Run();
    }
}