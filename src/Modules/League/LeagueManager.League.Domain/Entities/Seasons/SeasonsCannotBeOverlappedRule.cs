using LeagueManager.Domain.ValuesObjects;
using LeagueManager.League.Domain.Entities.Seasons;

namespace LeagueManager.Domain.Entities.Seasons;
public sealed class SeasonsCannotBeOverlappedRule(DateRange seasonDateRangeToValidate, IEnumerable<Season> existingSeasons) : IDomainValidator
{
    private readonly DateRange _seasonDateRangeToValidate = seasonDateRangeToValidate;

    private readonly IEnumerable<Season> _existingSeasons = existingSeasons;

    public DomainValidationResult Validate()
    {
        var result = new DomainValidationResult();

        foreach (var season in _existingSeasons)
        {
            result.ValidationErrors.AddRange(ValidateDateRanges(_seasonDateRangeToValidate, season));
        }

        return result;
    }

    private static IList<string> ValidateDateRanges(DateRange newSeasonDateRange, Season existingSeason)
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
