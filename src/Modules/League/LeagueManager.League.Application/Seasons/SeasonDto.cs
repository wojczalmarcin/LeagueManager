namespace LeagueManager.League.Application.Seasons;

//TODO: Teams, matches, statistics...
public sealed class SeasonDto()
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string? SponsorName { get; set; }
}
