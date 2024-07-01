using LeagueManager.Domain.ValuesObjects;

namespace LeagueManager.Domain.Entities.Seasons;
internal interface ISeasonValidator
{
    Task<DomainValidationResult> ValidateDateRangeAsync(DateRange seasonDateRange, CancellationToken cancellationToken = default);
}
