using LeagueManager.Domain.Exceptions;

namespace LeagueManager.Domain.ValuesObjects;
public sealed record DateRange
{
    public DateOnly StartDate { get; }
    public DateOnly EndDate { get; }

    public DateRange(DateOnly startDate, DateOnly endDate)
    {
        if (startDate < endDate)
            throw new InvalidDateRangeException("Ending date cannot be smaller than the stargind date.");

        StartDate = startDate;
        EndDate = endDate;
    }
}
