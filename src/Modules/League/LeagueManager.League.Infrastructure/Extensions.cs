using LeagueManager.Domain.Entities.Seasons;
using LeagueManager.League.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueManager.League.Infrastructure;
public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ISeasonRepository, SeasonRepository>();
        return services;
    }
}
