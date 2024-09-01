namespace LeagueManager.Shared.Abstractions.Domain;
public abstract class AgregateRoot<TId>(TId id) : Entity<TId>(id) where TId : DomainId
{
}

public abstract class AgregateRoot<TId, T> : Entity<TId, T> where TId : DomainId<T>
{
    protected AgregateRoot() : base() { }

    protected AgregateRoot(TId id) : base(id)
    {
    }

    protected AgregateRoot(T id) : base(id)
    {
    }
}