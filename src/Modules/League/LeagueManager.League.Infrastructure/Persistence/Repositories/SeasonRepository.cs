using LeagueManager.Domain.Entities.Seasons;

namespace LeagueManager.League.Infrastructure.Persistence.Repositories;
internal sealed class SeasonRepository : ISeasonRepository
{
    public Task CreateAsync(Season season, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Season>> GetAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Season> GetCurrentAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
