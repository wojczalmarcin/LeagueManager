using LeagueManager.Domain.Entities.Matches;
using LeagueManager.Domain.Entities.Teams;
using LeagueManager.Domain.ValuesObjects;
using LeagueManager.League.Domain.Entities.Seasons;
using LeagueManager.League.Domain.Entities.TeamsInSeasons;
using LeagueManager.League.Domain.ValuesObjects;

namespace LeagueManager.Domain.Entities.Seasons;

/// <summary>
/// Season agregate root class.
/// </summary>
public sealed class Season : AgregateRoot<SeasonId>
{
    /// <summary>
    /// Gets date range showing how long season will last.
    /// </summary>
    public DateRange DateRange { get; private set; }

    /// <summary>
    /// Gets the season sponsor if any.
    /// </summary>
    public Sponsor? Sponsor { get; private set; }

    /// <summary>
    /// Gets teams in the season.
    /// </summary>
    public IEnumerable<TeamInSeason> Teams => _teams.OrderBy(x => x.SeasonPoints)
        .ThenBy(x => x.MatechesPoints.PointsFor - x.MatechesPoints.PointsAgainst)
        .ThenBy(x => x.MatechesPoints.PointsFor)
        .ThenBy(x => x.MatechesPoints.PointsAgainst);

    /// <summary>
    /// Gets the season name.
    /// </summary>
    public string Name => $"{DateRange.StartDate.Year}/{DateRange.EndDate.Year}";

    /// <summary>
    /// Gets all season matches.
    /// </summary>
    public IReadOnlyList<Match> Matches => _matches;

    /// <summary>
    /// Gets season number of fixtures.
    /// </summary>
    public int FixturesCount => _teams.Count() * (_teams.Count() - 1);

    private readonly List<Match> _matches;

    private readonly List<TeamInSeason> _teams;

    internal Season(DateRange dateRange, IEnumerable<TeamId> teamsIds, Sponsor? sponsor = null)
    {
        DateRange = dateRange;
        Sponsor = sponsor;
        _matches = [];

        _teams = [];
        foreach (var teamId in teamsIds)
        {
            _teams.Add(new TeamInSeason(teamId));
        }
    }

    /// <summary>
    /// Adds new match to the season.
    /// </summary>
    /// <param name="match">Match to add.</param>
    /// <returns>Validation result of this operation.</returns>
    public DomainValidationResult AddMatch(Match match)
    {
        var result = new DomainValidationResult();
        if (_matches.Any(x => x.TeamHomeId == match.TeamHomeId && x.TeamAwayId == match.TeamAwayId))
            result.ValidationErrors.Add(SeasonMessages.MatchFixtureValidation);

        if (match.Fixture.Number > FixturesCount)
            result.ValidationErrors.Add(SeasonMessages.FixtureNumberValidation);

        if (result.IsValid)
            _matches.Add(match);

        return result;
    }

    /// <summary>
    /// Finishes match with the given identifier.
    /// </summary>
    /// <param name="matchId">Match identifier.</param>
    /// <returns>Validation result of this operation.</returns>
    public DomainValidationResult FinishMatch(MatchId matchId)
    {
        var result = new DomainValidationResult();
        var match = _matches.First(x => x.Id == matchId);

        var teamHome = _teams.First(x => x.TeamId == match.TeamHomeId);
        var teamAway = _teams.First(x => x.TeamId == match.TeamAwayId);

        if (match.AwayTeamPoints > match.HomeTeamPoints)
        {
            result.AddResult(teamAway.WinGame(new MatchesPoints(match.AwayTeamPoints, match.HomeTeamPoints)));
            result.AddResult(teamHome.LooseGame(new MatchesPoints(match.HomeTeamPoints, match.AwayTeamPoints)));
        }
        else if (match.AwayTeamPoints < match.HomeTeamPoints)
        {
            result.AddResult(teamHome.WinGame(new MatchesPoints(match.HomeTeamPoints, match.AwayTeamPoints)));
            result.AddResult(teamAway.LooseGame(new MatchesPoints(match.AwayTeamPoints, match.HomeTeamPoints)));
        }
        else
        {
            result.AddResult(teamAway.DrawGame(new MatchesPoints(match.AwayTeamPoints, match.HomeTeamPoints)));
            result.AddResult(teamHome.DrawGame(new MatchesPoints(match.HomeTeamPoints, match.AwayTeamPoints)));
        }
        var finishResult = match.Finish();

        result.AddResult(finishResult);
        return result;
    }
}

public sealed record SeasonId(Guid Value) : IValueObject;
