namespace LeagueManager.Shared.Abstractions.Domain;
public abstract record UlidId : IValueObject
{
    public Guid Value { get; }

    public UlidId()
    {
        Value = Ulid.NewUlid().ToGuid();
    }
}
