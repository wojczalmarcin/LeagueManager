using LeagueManager.League.Domain.Entities.Players;
using LeagueManager.League.Domain.ValuesObjects;

namespace LeagueManager.Domain.Entities.Teams;
public sealed class Team : AgregateRoot<TeamId>
{
    public string Name { get; }

    public Address Address { get; }

    public Stadium Stadium { get; }

    public IEnumerable<PlayerId> PlayersIds => PlayersIds;

    private readonly List<PlayerId> _playersIds;

    internal Team(string name, Address address, Stadium stadium) : base()
    {
        Address = address;
        Stadium = stadium;
        Name = name;
        _playersIds = [];
    }

    public DomainValidationResult AddPlayerAsync(Player player)
    {
        var result = new DomainValidationResult();
        _playersIds.Add(player.Id);

        return result;
    }
}

public sealed record TeamId() : UlidId;