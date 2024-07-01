using LeagueManager.Domain.Entities.Teams;
using LeagueManager.League.Domain.ValuesObjects;

namespace LeagueManager.League.Domain.Entities.TeamsInSeasons;
public class TeamInSeason : Entity<TeamInSeasonId>
{
    public TeamId TeamId { get; }

    public int Won { get; private set; }

    public int Drawn { get; private set; }

    public int Lost { get; private set; }

    public MatchesPoints MatechesPoints { get; private set; }

    public int SeasonPoints => CalculateSeasonPoints();

    internal TeamInSeason(TeamId teamId)
    {
        TeamId = teamId;
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
}
public sealed record TeamInSeasonId(Guid Value) : IValueObject;