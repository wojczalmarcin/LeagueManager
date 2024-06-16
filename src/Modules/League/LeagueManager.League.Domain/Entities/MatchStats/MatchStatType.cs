using LeagueManager.Shared.Abstractions.Domain;

namespace LeagueManager.League.Domain.Entities.MatchStats;
public sealed class MatchStatType : IEntity
{
    public Guid Id { get; }

    public string Name { get; }

    public bool IsPoint { get; set; }

    public MatchStatType(string name, bool isPoint)
    {
        Name = name;
        IsPoint = isPoint;
    }
}