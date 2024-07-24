using LeagueManager.League.Domain.ValuesObjects;

namespace LeagueManager.League.Domain.Entities.Players;

// Separate module ?
public sealed class Player : AgregateRoot<PlayerId>
{
    public PersonalInfo PersonalInfo { get; }

    public Player(PersonalInfo personalInfo) : base()
    {
        PersonalInfo = personalInfo;
    }
}

public sealed record PlayerId() : UlidId;