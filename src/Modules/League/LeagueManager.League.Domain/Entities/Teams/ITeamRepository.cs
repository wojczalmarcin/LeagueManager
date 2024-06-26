using LeagueManager.Domain.Entities.Teams;

namespace LeagueManager.League.Domain.Entities.Teams;
public interface ITeamRepository
{
    Task<IReadOnlyList<Team>> GetAsync();

    Task<IReadOnlyList<Team>> GetAsync(IEnumerable<Guid> teamsIds);

    Task<Team> GetAsync(Guid teamId);
}
