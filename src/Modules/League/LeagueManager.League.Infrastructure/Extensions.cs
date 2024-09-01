using LeagueManager.Domain.Entities.Seasons;
using LeagueManager.League.Application.Seasons;
using LeagueManager.League.Domain.Entities.Teams;
using LeagueManager.League.Infrastructure.Mappers;
using LeagueManager.League.Infrastructure.Persistence;
using LeagueManager.League.Infrastructure.Persistence.Repositories;
using LeagueManager.Shared.Infrastructure.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueManager.League.Infrastructure;
public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ISeasonRepository, SeasonRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();

        services.AddDbContext<LeagueDbContext>(
            o => o.UseNpgsql(services.GetSection<LeagueDatabaseConfig>("LeagueDatabase").ConnectionString));

        services.AddScoped<ISeasonContractMapper, SeasonContractMapper>();
        return services;
    }

    public static void ApplyDatabaseMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        using var dbContext = scope.ServiceProvider.GetRequiredService<LeagueDbContext>();

        dbContext.Database.Migrate();
    }
}
