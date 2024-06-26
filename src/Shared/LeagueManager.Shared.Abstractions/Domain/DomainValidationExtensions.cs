namespace LeagueManager.Shared.Abstractions.Domain;
public static class DomainValidationExtensions
{
    public static DomainValidationResult AddResult(this DomainValidationResult result, DomainValidationResult resultToAdd)
    {
        if (resultToAdd != null)
        {
            result.ValidationErrors.AddRange(resultToAdd.ValidationErrors);
        }

        return result;
    }
}
