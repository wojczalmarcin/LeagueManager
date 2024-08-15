using LeagueManager.Domain.Entities.Teams;
using LeagueManager.League.Domain.Entities.Players;

namespace LeagueManager.League.Domain.Entities.Seasons.MatchStats;
public sealed class MatchStat : Entity<MatchStatId>
{
    public PlayerId PlayerId { get; }
    public TeamId TeamId { get; }
    public MatchStatType StatType { get; }
    public int Minute { get; }

    public MatchStat(PlayerId playerId, TeamId teamId, MatchStatType statType, int minute) : base()
    {
        PlayerId = playerId;
        TeamId = teamId;
        StatType = statType;
        Minute = minute;
    }
}
public sealed record MatchStatId() : UlidId;