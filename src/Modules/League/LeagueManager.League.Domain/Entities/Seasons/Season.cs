using LeagueManager.Domain.Entities.Matches;
using LeagueManager.Domain.ValuesObjects;
using LeagueManager.League.Domain.Entities.Seasons;
using LeagueManager.Shared.Abstractions.Domain;

namespace LeagueManager.Domain.Entities.Seasons;

/// <summary>
/// Season agregate root class.
/// </summary>
public sealed class Season : IAgregateRoot
{
    /// <summary>
    /// Gets the season identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets date range showing how long season will last.
    /// </summary>
    public DateRange DateRange { get; private set; }

    /// <summary>
    /// Gets the season sponsor if any.
    /// </summary>
    public Sponsor? Sponsor { get; private set; }

    /// <summary>
    /// Gets identifiers of the teams participating in this season.
    /// </summary>
    public IEnumerable<Guid> TeamsIds => _teamsIds;

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
    public int FixturesCount => _teamsIds.Count * (_teamsIds.Count - 1);

    private readonly List<Match> _matches;

    private readonly HashSet<Guid> _teamsIds;

    internal Season(DateRange dateRange, IEnumerable<Guid> teamsIds, Sponsor? sponsor = null)
    {
        DateRange = dateRange;
        _teamsIds = teamsIds.ToHashSet();
        Sponsor = sponsor;
        _matches = [];
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

        if(match.Fixture.Number > FixturesCount)
            result.ValidationErrors.Add(SeasonMessages.FixtureNumberValidation);

        if (result.IsValid)
            _matches.Add(match);

        return result;
    }
}
