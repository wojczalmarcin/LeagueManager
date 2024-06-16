using LeagueManager.Domain.ValuesObjects;
using LeagueManager.League.Domain.Entities.Seasons;
using LeagueManager.Shared.Abstractions.Domain;

namespace LeagueManager.Domain.Entities.Seasons;
internal class SeasonValidator : ISeasonValidator
{
    private readonly ISeasonRepository _seasonRepository;

    public SeasonValidator(ISeasonRepository seasonRepository)
    {
        _seasonRepository = seasonRepository;
    }

    public async Task<DomainValidationResult> ValidateDateRangeAsync(DateRange newSeasonDateRange)
    {
        var seasons = (await _seasonRepository.GetAsync()).ToList();
        var result = new DomainValidationResult();

        foreach (var season in seasons)
        {
            result.ValidationErrors.AddRange(ValidateTwoSeasons(newSeasonDateRange, season));
        }

        return result;
    }

    private static IList<string> ValidateTwoSeasons(DateRange newSeasonDateRange, Season existingSeason)
    {
        var errors = new List<string>();

        if (newSeasonDateRange.StartDate.Year == existingSeason.DateRange.StartDate.Year)
            errors.Add(string.Format(SeasonMessages.StartingYearValidation, newSeasonDateRange.StartDate.Year));

        if (newSeasonDateRange.StartDate < existingSeason.DateRange.EndDate && 
            newSeasonDateRange.EndDate > existingSeason.DateRange.StartDate)
            errors.Add(string.Format(SeasonMessages.StartingDayValidation, existingSeason.Name));

        return errors;
    }
}
