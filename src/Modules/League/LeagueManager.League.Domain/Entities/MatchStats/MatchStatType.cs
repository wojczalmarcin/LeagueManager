namespace LeagueManager.League.Domain.Entities.MatchStats;
public sealed class MatchStatType : IEntity
{
    public Guid Id { get; }

    public string Name { get; }

    public int Points { get; set; }

    public MatchStatType(string name, int points)
    {
        Name = name;
        Points = points;
    }
}