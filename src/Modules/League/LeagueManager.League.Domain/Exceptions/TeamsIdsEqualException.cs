namespace LeagueManager.Domain.Exceptions;

[Serializable]
internal class TeamsIdsEqualException : DomainValidationException
{
    public TeamsIdsEqualException(string message) : base(message)
    {
    }
}
