namespace LeagueManager.League.Domain.Entities.MatchStats;
public sealed class MatchStatType : Entity<MatchStatTypeId>
{
    public string Name { get; }

    public int Points { get; set; }

    public MatchStatType(string name, int points) : base()
    {
        Name = name;
        Points = points;
    }
}

public sealed record MatchStatTypeId() : UlidId;