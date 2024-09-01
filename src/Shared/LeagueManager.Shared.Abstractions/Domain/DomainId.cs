namespace LeagueManager.Shared.Abstractions.Domain;

public abstract record DomainId(object Value) : IValueObject
{
}

public record DomainId<T>(T Value) : DomainId(Value!)
{
    public new T Value => (T)base.Value;
}