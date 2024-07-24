namespace LeagueManager.Shared.Abstractions.Domain;
public abstract class Entity<TId> where TId : new()
{
    public TId Id { get; protected set; }

    protected Entity()
    {
        Id = new();
    }
}
