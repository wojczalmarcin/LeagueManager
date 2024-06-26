namespace LeagueManager.League.Application.Seasons;
public sealed class TableDto
{
    public required IEnumerable<TeamInTableDto> Teams { get; set; }
}
