using LeagueManager.League.Application;
using LeagueManager.League.Domain;
using LeagueManager.League.Infrastructure;
using LeagueManager.League.WebApi.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueManager.League.WebApi;
public static class Extensions
{
    public static IServiceCollection AddLeagueModule(this IServiceCollection services)
    {
        services.AddDomain();
        services.AddApplication();
        services.AddInfrastructure();
        return services;
    }

    public static WebApplication UseLeagueWebApi(this WebApplication app)
    {
        app.UseSeasonEndpoints();
        return app;
    }
}
