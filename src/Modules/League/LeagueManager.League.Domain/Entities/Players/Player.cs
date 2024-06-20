using LeagueManager.League.Domain.ValuesObjects;
using LeagueManager.Shared.Abstractions.Domain;

namespace LeagueManager.League.Domain.Entities.Players;

// Separate module ?
public sealed class Player : IAgregateRoot
{
    public Guid Id { get; }

    public PersonalInfo PersonalInfo { get; }

    public Player(PersonalInfo personalInfo)
    {
        PersonalInfo = personalInfo;
    }
}
