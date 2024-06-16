using LeagueManager.Domain.Exceptions;
using LeagueManager.Domain.ValuesObjects;
using LeagueManager.League.Domain.Entities.MatchStats;
using LeagueManager.Shared.Abstractions.Domain;

namespace LeagueManager.Domain.Entities.Matches;
public sealed class Match : IEntity
{
    public Guid Id { get; }

    public Guid TeamHomeId { get; }

    public Guid TeamAwayId { get; }

    public SeasonFixture Fixture { get; }

    public bool IsFinished { get; }

    public int? StadiumId { get; }

    public DateTime? Date { get; private set; }

    public IEnumerable<MatchStat> MatchStats => MatchStats;

    public int HomeTeamPoints => _matchstats.Where(x => x.TeamId == TeamHomeId && x.StatType.IsPoint).Count();

    public int AwayTeamPoints => _matchstats.Where(x => x.TeamId == TeamAwayId && x.StatType.IsPoint).Count();

    private readonly TimeProvider _timeProvider;

    private readonly List<MatchStat> _matchstats;

    internal Match(Guid teamHomeId, Guid teamAwayId, SeasonFixture fixture, TimeProvider timeProvider)
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
            result.ValidationErrors.Add(League.Domain.Entities.Matches.MatchMessages.MatchDateValidation);

        if(result.IsValid)
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
    public DomainValidationResult AddMatchStat(Guid playerId, Guid teamId, MatchStatType statType, int minute)
    {
        var result = new DomainValidationResult();
        _matchstats.Add(new MatchStat(playerId, teamId, statType, minute));

        return result;
    }
}
