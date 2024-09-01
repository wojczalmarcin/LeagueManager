using LeagueManager.League.Domain.Entities.Seasons.TeamsInSeasons;
using LeagueManager.League.Domain.ValuesObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueManager.League.Infrastructure.Persistence.EntitiesConfiguration;

internal sealed class TeamsInSeasonsConfig : IEntityTypeConfiguration<TeamInSeason>
{
    public void Configure(EntityTypeBuilder<TeamInSeason> builder)
    {
        MapSeasonsTeamsInSeasons(builder);
    }

    // TeamInSeason cannot be configured as a OwnedNavigationBuilder of the Seasons, 
    // because ComplexProperty cannot be configured with the OwnedNavigationBuilder
    // causing snapshot code compile error
    public static void MapSeasonsTeamsInSeasons(EntityTypeBuilder<TeamInSeason> builder)
    {
        builder.ToTable("TeamsInSeasons");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value.ToByteArray(),
                x => new TeamInSeasonId(new Ulid(x)));
        builder.ComplexProperty(x => x.MatechesPoints, x =>
        {
            x.Property(z => z.PointsFor).HasColumnName(nameof(MatchesPoints.PointsFor));
            x.Property(z => z.PointsAgainst).HasColumnName(nameof(MatchesPoints.PointsAgainst));
        });
    }
}
