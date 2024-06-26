using LeagueManager.League.Domain.Entities.Players;
using LeagueManager.League.Domain.ValuesObjects;
using LeagueManager.Shared.Abstractions.Domain;

namespace LeagueManager.Domain.Entities.Teams;
public sealed class Team : IAgregateRoot
{
    public Guid Id { get; }

    public string Name { get; }

    public Address Address { get; }

    public Stadium Stadium { get; }

    public IEnumerable<Guid> PlayersIds => PlayersIds;

    private List<Guid> _playersIds;

    internal Team(string name, Address address, Stadium stadium)
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
