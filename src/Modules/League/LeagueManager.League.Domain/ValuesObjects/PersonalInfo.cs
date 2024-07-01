namespace LeagueManager.League.Domain.ValuesObjects;
public sealed record PersonalInfo(string FirstName, string LastName, string EmailAddress) : IValueObject;
