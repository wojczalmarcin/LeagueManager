using LeagueManager.Domain.ValuesObjects;
using LeagueManager.Shared.Abstractions.Domain;
using OneOf;

namespace LeagueManager.Domain.Entities.Seasons;
internal sealed class SeasonFactory : ISeasonFactory
{
    private readonly ISeasonValidator _seasonDatesValidator;

    public SeasonFactory(ISeasonValidator seasonDatesValidator)
    {
        _seasonDatesValidator = seasonDatesValidator;
    }

    public async Task<OneOf<Season, DomainValidationResult>> CreateAsync(DateOnly startDate, DateOnly endDate, 
        IEnumerable<Guid> teamsIds, Sponsor? sponsor = null, CancellationToken cancellationToken = default)
    {
        try
        {
            var dateRange = new DateRange(startDate, endDate);
            var datesResult = await _seasonDatesValidator.ValidateDateRangeAsync(dateRange);
            if (datesResult.IsValid)
            {
                var season = new Season(dateRange, teamsIds, sponsor);
            }

            return datesResult;
        }
        catch (DomainValidationException ex)
        {
            return new DomainValidationResult([ex.Message]);
        }
    }
}
