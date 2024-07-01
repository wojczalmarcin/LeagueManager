namespace LeagueManager.League.Domain.ValuesObjects;
public record struct MatchesPoints(int PointsFor, int PointsAgainst) : IValueObject
{
    public static MatchesPoints operator +(MatchesPoints a, MatchesPoints b)
        => new(a.PointsFor + b.PointsFor, a.PointsAgainst + b.PointsAgainst);
}
