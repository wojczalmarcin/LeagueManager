using LeagueManager.Domain.Entities.Teams;

namespace LeagueManager.League.Application.Teams.Ports;
public interface ITeamRepository
{
    Task<IReadOnlyList<Team>> GetAsync();

    Task<IReadOnlyList<Team>> GetAsync(IEnumerable<TeamId> teamsIds);

    Task<Team> GetAsync(TeamId teamId);
}
