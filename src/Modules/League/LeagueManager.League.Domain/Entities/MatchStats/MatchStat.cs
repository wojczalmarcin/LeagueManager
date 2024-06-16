using LeagueManager.Shared.Abstractions.Domain;

namespace LeagueManager.League.Domain.Entities.MatchStats;
public sealed class MatchStat : IEntity
{
    public Guid Id { get; }
    public Guid PlayerId { get; }
    public Guid TeamId { get; }
    public MatchStatType StatType { get; }
    public int Minute { get; }

    public MatchStat(Guid playerId, Guid teamId, MatchStatType statType, int minute)
    {
        PlayerId = playerId;
        TeamId = teamId;
        StatType = statType;
        Minute = minute;
    }
}
