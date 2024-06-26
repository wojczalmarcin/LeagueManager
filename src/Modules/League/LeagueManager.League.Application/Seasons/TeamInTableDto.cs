using LeagueManager.League.Application.Teams;

namespace LeagueManager.League.Application.Seasons;
public sealed class TeamInTableDto
{
    public TeamDto Team { get; set; }

    public int Won { get; set; }

    public int Drawn { get; set; }

    public int Lost { get; set; }

    public int GoalsAgainst { get; set; }

    public int GoalsFor { get; set; }

    public int Points { get; set; }
}
