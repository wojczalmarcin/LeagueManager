namespace LeagueManager.Domain.Entities.Seasons;
public interface ISeasonRepository
{
    /// <summary>
    /// Gets all of the leagie seasons asynchronously.
    /// </summary>
    /// <returns>Collection of seasons.</returns>
    Task<IEnumerable<Season>> GetAsync();

    /// <summary>
    /// Creates season asynchronously.
    /// </summary>
    Task CreateAsync(Season season);
}
