namespace LeagueManager.Domain.ValuesObjects;
public sealed record SeasonFixture
{
    public int Number { get; set; }

    public SeasonFixture(int number)
    {
        if (number < 1)
            throw new ArgumentOutOfRangeException(nameof(number), "Season fixture number must be positive.");
        Number = number;
    }
}
