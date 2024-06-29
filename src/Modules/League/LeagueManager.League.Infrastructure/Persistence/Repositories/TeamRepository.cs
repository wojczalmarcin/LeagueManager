using LeagueManager.Domain.Entities.Teams;
using LeagueManager.League.Domain.Entities.Teams;

namespace LeagueManager.League.Infrastructure.Persistence.Repositories;
internal sealed class TeamRepository : ITeamRepository
{
    public Task<IReadOnlyList<Team>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Team>> GetAsync(IEnumerable<Guid> teamsIds)
    {
        throw new NotImplementedException();
    }

    public Task<Team> GetAsync(Guid teamId)
    {
        throw new NotImplementedException();
    }
}
