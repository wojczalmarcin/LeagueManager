using LeagueManager.Domain.Entities.Teams;

namespace LeagueManager.League.Domain.Entities.Teams;
public interface ITeamRepository
{
    Task<IReadOnlyList<Team>> GetAsync();

    Task<IReadOnlyList<Team>> GetAsync(IEnumerable<TeamId> teamsIds);

    Task<Team> GetAsync(TeamId teamId);
}
