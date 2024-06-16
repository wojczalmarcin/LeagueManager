using LeagueManager.Domain.Entities.Seasons;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueManager.League.Domain;
public static class Extensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<ISeasonValidator, SeasonValidator>();
        services.AddScoped<ISeasonFactory, SeasonFactory>();

        return services;
    }
}
