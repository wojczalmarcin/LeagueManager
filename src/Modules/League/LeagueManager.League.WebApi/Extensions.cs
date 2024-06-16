using LeagueManager.League.Application;
using LeagueManager.League.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueManager.League.WebApi;
public static class Extensions
{
    public static IServiceCollection AddLeagueApi(this IServiceCollection services)
    {
        services.AddDomain();
        services.AddApplication();
        return services;
    }
}
