using LeagueManager.Domain.Entities.Teams;
using LeagueManager.League.Domain.ValuesObjects;

namespace LeagueManager.League.Domain.Entities.Seasons.TeamsInSeasons;
public class TeamInSeason : Entity<TeamInSeasonId, Ulid>
{
    public TeamId TeamId { get; }

    public int Won { get; private set; }

    public int Drawn { get; private set; }

    public int Lost { get; private set; }

    public MatchesPoints MatechesPoints { get; private set; }

    public int SeasonPoints => CalculateSeasonPoints();

    internal TeamInSeason(TeamInSeasonId id, TeamId teamId, int won = 0, int drawn = 0, int lost = 0) : base(id)
    {
        TeamId = teamId;
        Won = won;
        Drawn = drawn;
        Lost = lost;
    }

    public DomainValidationResult WinGame(MatchesPoints goals)
    {
        Won += 1;
        MatechesPoints += goals;
        return new DomainValidationResult();
    }

    public DomainValidationResult LooseGame(MatchesPoints goals)
    {
        Lost += 1;
        MatechesPoints += goals;
        return new DomainValidationResult();
    }

    public DomainValidationResult DrawGame(MatchesPoints goals)
    {
        Drawn += 1;
        MatechesPoints += goals;
        return new DomainValidationResult();
    }


    private int CalculateSeasonPoints()
    {
        //TODO: some configuration
        return Won * 3 + Drawn;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private TeamInSeason() : base()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
}
public sealed record TeamInSeasonId(Ulid Value) : DomainId<Ulid>(Value);