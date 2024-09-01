namespace LeagueManager.Shared.Abstractions.Domain;
public abstract class Entity<TId>(TId id) where TId : DomainId
{
    public TId Id { get; protected set; } = id;
}

public abstract class Entity<TId, T> where TId : DomainId<T>
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Entity() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public Entity(TId id) => Id = id;

    public Entity(T id)
    {
        var domainIdType = typeof(TId);
        var constr = domainIdType.GetConstructor([typeof(T)]);
        Id = (TId)constr!.Invoke([id]);
    }

    public TId Id { get; protected set; }
}