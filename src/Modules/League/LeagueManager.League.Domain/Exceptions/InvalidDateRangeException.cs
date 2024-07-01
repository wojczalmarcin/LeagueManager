namespace LeagueManager.Domain.Exceptions;

[Serializable]
internal class InvalidDateRangeException : DomainValidationException
{
    public InvalidDateRangeException(string message) : base(message)
    {
    }
}
