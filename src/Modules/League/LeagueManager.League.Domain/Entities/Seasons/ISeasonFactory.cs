using LeagueManager.Domain.Entities.Teams;
using LeagueManager.Domain.ValuesObjects;
using OneOf;

namespace LeagueManager.Domain.Entities.Seasons;
public interface ISeasonFactory
{
    //Task<OneOf<Season, DomainValidationResult>> CreateAsync(DateOnly startDate, DateOnly endDate,
    //    IEnumerable<TeamId> teamsIds, Sponsor? sponsor = null, CancellationToken cancellationToken = default);
}
