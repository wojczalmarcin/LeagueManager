namespace LeagueManager.League.Domain.Entities.Seasons.MatchStats;
public sealed class MatchStatType : Entity<MatchStatTypeId, Ulid>
{
    public string Name { get; }

    public int Points { get; set; }

    public MatchStatType(MatchStatTypeId id, string name, int points) : base(id)
    {
        Name = name;
        Points = points;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private MatchStatType() : base()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
}

public sealed record MatchStatTypeId(Ulid Value) : DomainId<Ulid>(Value);