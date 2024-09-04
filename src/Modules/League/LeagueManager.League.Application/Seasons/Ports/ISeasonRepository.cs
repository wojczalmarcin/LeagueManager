using LeagueManager.Domain.Entities.Seasons;

namespace LeagueManager.League.Application.Seasons.Ports;
public interface ISeasonRepository
{
    /// <summary>
    /// Gets all of the leagie seasons asynchronously.
    /// </summary>
    /// <returns>Collection of seasons.</returns>
    Task<IEnumerable<Season>> GetAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Creates season asynchronously.
    /// </summary>
    Task CreateAsync(Season season, CancellationToken cancellationToken);

    /// <summary>
    /// Gets ongoing season asynchronously.
    /// </summary>
    /// <returns>Current season.</returns>
    Task<Season> GetCurrentAsync(CancellationToken cancellationToken);
}
