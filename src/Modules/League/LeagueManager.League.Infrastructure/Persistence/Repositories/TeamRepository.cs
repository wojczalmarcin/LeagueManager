using LeagueManager.Domain.Entities.Teams;
using LeagueManager.League.Application.Teams.Ports;

namespace LeagueManager.League.Infrastructure.Persistence.Repositories;
internal sealed class TeamRepository : ITeamRepository
{
    public Task<IReadOnlyList<Team>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Team>> GetAsync(IEnumerable<TeamId> teamsIds)
    {
        throw new NotImplementedException();
    }

    public Task<Team> GetAsync(TeamId teamId)
    {
        throw new NotImplementedException();
    }
}
