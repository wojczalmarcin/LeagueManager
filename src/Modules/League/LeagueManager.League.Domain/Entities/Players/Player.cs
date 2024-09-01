using LeagueManager.League.Domain.ValuesObjects;

namespace LeagueManager.League.Domain.Entities.Players;

// Separate module ?
public sealed class Player : AgregateRoot<PlayerId>
{
    public PersonalInfo PersonalInfo { get; }

    public Player(PlayerId id, PersonalInfo personalInfo) : base(id)
    {
        PersonalInfo = personalInfo;
    }
}

public sealed record PlayerId(Ulid Value) : DomainId<Ulid>(Value);