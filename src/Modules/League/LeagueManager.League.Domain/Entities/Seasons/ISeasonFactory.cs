using LeagueManager.Domain.ValuesObjects;
using LeagueManager.Shared.Abstractions.Domain;
using OneOf;

namespace LeagueManager.Domain.Entities.Seasons;
public interface ISeasonFactory
{
    Task<OneOf<Season, DomainValidationResult>> CreateAsync(DateOnly startDate, DateOnly endDate,
        IEnumerable<Guid> teamsIds, Sponsor? sponsor = null, CancellationToken cancellationToken = default);
}
