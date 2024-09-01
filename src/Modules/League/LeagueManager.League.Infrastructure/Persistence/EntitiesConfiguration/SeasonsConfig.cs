using LeagueManager.Domain.Entities.Seasons;
using LeagueManager.Domain.ValuesObjects;
using LeagueManager.League.Domain.Entities.Seasons.Matches;
using LeagueManager.League.Domain.Entities.Seasons.MatchStats;
using LeagueManager.League.Domain.Entities.Seasons.TeamsInSeasons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueManager.League.Infrastructure.Persistence.Mapping;
internal sealed class SeasonsConfig : IEntityTypeConfiguration<Season>
{
    public void Configure(EntityTypeBuilder<Season> builder)
    {
        MapSeasons(builder);
        MapTeamsInSeasons(builder);
        MapMatches(builder);
    }

    public static void MapSeasons(EntityTypeBuilder<Season> builder)
    {
        builder.ToTable("Seasons");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value.ToByteArray(),
                x => new SeasonId(new Ulid(x)));

        builder.ComplexProperty(x => x.DateRange, y =>
        {
            y.Property(z => z.StartDate).HasColumnName(nameof(DateRange.StartDate));
            y.Property(x => x.EndDate).HasColumnName(nameof(DateRange.EndDate));
        });

        builder.OwnsOne(x => x.Sponsor);
    }

    public static void MapMatches(EntityTypeBuilder<Season> builder)
    {
        builder.OwnsMany(x => x.Matches, nb =>
        {
            nb.WithOwner().HasForeignKey("SeasonId");
            nb.ToTable("Matches");
            nb.HasKey("Id");
            nb.Property(y => y.Id)
                .ValueGeneratedNever()
                .HasConversion(y => y.Value.ToByteArray(),
                        y => new MatchId(new Ulid(y)));
            MapMatchesStats(nb);
           });
    }

    public static void MapMatchesStats(OwnedNavigationBuilder<Season, Match> builder)
    {
        builder.OwnsMany(x => x.MatchStats, nb =>
        {
            nb.WithOwner().HasForeignKey("MatchId");
            nb.ToTable("MatchesStats");
            nb.HasKey("Id");
            nb.Property(y => y.Id)
                .ValueGeneratedNever()
                .HasConversion(y => y.Value.ToByteArray(),
                     y => new MatchStatId(new Ulid(y)));
        });
    }

    public static void MapTeamsInSeasons(EntityTypeBuilder<Season> builder)
    {
        builder.HasMany(x => x.Teams)
            .WithOne()
            .HasForeignKey("SeasonId");
    }
}
