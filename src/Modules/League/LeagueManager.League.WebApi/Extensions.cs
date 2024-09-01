using FluentValidation;
using LeagueManager.Application.Seasons;
using LeagueManager.League.Application;
using LeagueManager.League.Domain;
using LeagueManager.League.Infrastructure;
using LeagueManager.League.WebApi.Endpoints;
using LeagueManager.League.WebApi.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LeagueManager.League.WebApi;
public static class Extensions
{
    public static IServiceCollection AddLeagueModule(this IServiceCollection services)
    {
        services.AddDomain();
        services.AddApplication();
        services.AddInfrastructure();

        services.AddScoped<IValidator<CreateSeasonCommand>, CreateSeasonValidator>();

        return services;
    }

    public static WebApplication UseLeagueWebApi(this WebApplication app)
    {
        app.UseSeasonEndpoints();

        if (app.Environment.IsDevelopment())
        {
            app.ApplyDatabaseMigrations();
        }
        
        return app;
    }
}
