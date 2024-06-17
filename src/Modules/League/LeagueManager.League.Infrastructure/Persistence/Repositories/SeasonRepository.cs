using LeagueManager.Domain.Entities.Seasons;

namespace LeagueManager.League.Infrastructure.Persistence.Repositories;
internal sealed class SeasonRepository : ISeasonRepository
{
    public Task CreateAsync(Season season)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Season>> GetAsync()
    {
        throw new NotImplementedException();
    }
}
