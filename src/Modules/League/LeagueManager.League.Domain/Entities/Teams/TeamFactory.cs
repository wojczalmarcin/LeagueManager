using LeagueManager.Domain.Entities.Teams;
using LeagueManager.League.Domain.ValuesObjects;
using OneOf;

namespace LeagueManager.League.Domain.Entities.Teams;
internal class TeamFactory : ITeamFactory
{
    private readonly ITeamValidator _teamValidator;

    public TeamFactory(ITeamValidator teamValidator)
    {
        _teamValidator = teamValidator;
    }

    public async Task<OneOf<Team, DomainValidationResult>> CreateAsync(string name, Address address, Stadium stadium)
    {
        try
        {
            var datesResult = await _teamValidator.ValidateTeamExistenceAsync(name);
            if (datesResult.IsValid)
            {
                var season = new Team(new TeamId(Ulid.NewUlid()), name, address, stadium);
            }

            return datesResult;
        }
        catch (DomainValidationException ex)
        {
            return new DomainValidationResult([ex.Message]);
        }
    }
}
