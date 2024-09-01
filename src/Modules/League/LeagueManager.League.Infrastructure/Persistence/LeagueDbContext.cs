using LeagueManager.Domain.Entities.Seasons;
using LeagueManager.League.Domain.Entities.Seasons.TeamsInSeasons;
using LeagueManager.League.Domain.ValuesObjects;
using LeagueManager.League.Infrastructure.Persistence.Mapping;
using LeagueManager.Shared.Abstractions.Domain;
using LeagueManager.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LeagueManager.League.Infrastructure.Persistence;
internal sealed class LeagueDbContext : DbContext
{
    //TEMP
    public LeagueDbContext() { }

    public LeagueDbContext(DbContextOptions<LeagueDbContext> options)
    : base(options)
    {
    }

    //TEMP
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    {

        optionsBuilder.UseNpgsql("Write your database connection string");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeagueDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<Ulid>()
            .HaveConversion<UlidToBytesConverter>();

        configurationBuilder.ComplexProperties<MatchesPoints>();
    }

    public DbSet<Season> Seasons { get; set; }
}