namespace LeagueManager.Shared.Abstractions.Domain;
public class DomainValidationResult
{
    public List<string> ValidationErrors { get; set; }

    public bool IsValid => !ValidationErrors.Any();

    public DomainValidationResult()
    {
        ValidationErrors = new List<string>();
    }

    public DomainValidationResult(IEnumerable<string> validationErrors)
    {
        ValidationErrors = validationErrors.ToList();
    }
}
