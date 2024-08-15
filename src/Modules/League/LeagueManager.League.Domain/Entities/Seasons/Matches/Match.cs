using LeagueManager.Domain.Entities.Teams;
using LeagueManager.Domain.Exceptions;
using LeagueManager.Domain.ValuesObjects;
using LeagueManager.League.Domain.Entities.Players;
using LeagueManager.League.Domain.Entities.Seasons.MatchStats;

namespace LeagueManager.League.Domain.Entities.Seasons.Matches;
public sealed class Match : Entity<MatchId>
{
    public TeamId TeamHomeId { get; }

    public TeamId TeamAwayId { get; }

    public SeasonFixture Fixture { get; }

    public bool IsFinished { get; private set; }

    public int? StadiumId { get; }

    public DateTime? Date { get; private set; }

    public IEnumerable<MatchStat> MatchStats => MatchStats;

    public int HomeTeamPoints => _matchstats.Where(x => x.TeamId == TeamHomeId).Sum(x => x.StatType.Points);

    public int AwayTeamPoints => _matchstats.Where(x => x.TeamId == TeamAwayId).Sum(x => x.StatType.Points);


    private readonly TimeProvider _timeProvider;

    private readonly List<MatchStat> _matchstats;

    internal Match(TeamId teamHomeId, TeamId teamAwayId, SeasonFixture fixture, TimeProvider timeProvider) : base()
    {
        if (teamHomeId == teamAwayId)
            throw new TeamsIdsEqualException("Match cannot have home team same as away team.");

        TeamHomeId = teamHomeId;
        TeamAwayId = teamAwayId;
        Fixture = fixture;
        _timeProvider = timeProvider;
        _matchstats = [];
    }


    /// <summary>
    /// Sets date of this match
    /// </summary>
    /// <param name="date">Match date to set.</param>
    /// <returns>Validation result of this operation.</returns>
    public DomainValidationResult SetDate(DateTime date)
    {
        var result = new DomainValidationResult();
        if (date < _timeProvider.GetLocalNow())
            result.ValidationErrors.Add(MatchMessages.MatchDateValidation);

        if (result.IsValid)
            Date = date;

        return result;
    }

    /// <summary>
    /// Adds match statistics.
    /// </summary>
    /// <param name="playerId">Player identifier.</param>
    /// <param name="teamId">Team identifier.</param>
    /// <param name="statType">Stat type.</param>
    /// <param name="minute">Minute of the statistic.</param>
    /// <returns>Validation result of this operation.</returns>
    public DomainValidationResult AddMatchStat(PlayerId playerId, TeamId teamId, MatchStatType statType, int minute)
    {
        var result = new DomainValidationResult();
        _matchstats.Add(new MatchStat(playerId, teamId, statType, minute));

        return result;
    }

    public DomainValidationResult Finish()
    {
        var result = new DomainValidationResult();
        IsFinished = true;
        return result;
    }
}

public sealed record MatchId() : UlidId;
