using LeagueManager.Domain.ValuesObjects;
using LeagueManager.Shared.Abstractions.Domain;

namespace LeagueManager.Domain.Entities.Seasons;
internal interface ISeasonValidator
{
    Task<DomainValidationResult> ValidateDateRangeAsync(DateRange seasonDateRange);
}
