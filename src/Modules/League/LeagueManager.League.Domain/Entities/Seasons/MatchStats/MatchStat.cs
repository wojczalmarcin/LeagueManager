using LeagueManager.Domain.Entities.Teams;
using LeagueManager.League.Domain.Entities.Players;

namespace LeagueManager.League.Domain.Entities.Seasons.MatchStats;
public sealed class MatchStat : Entity<MatchStatId, Ulid>
{
    public PlayerId PlayerId { get; }
    public TeamId TeamId { get; }
    public MatchStatType StatType { get; }
    public int Minute { get; }

    public MatchStat(MatchStatId id, PlayerId playerId, TeamId teamId, MatchStatType statType, int minute) : base(id)
    {
        PlayerId = playerId;
        TeamId = teamId;
        StatType = statType;
        Minute = minute;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private MatchStat() : base()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
}
public sealed record MatchStatId(Ulid Value) : DomainId<Ulid>(Value);