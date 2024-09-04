using LeagueManager.League.Domain.Entities.Players;
using LeagueManager.League.Domain.Entities.Teams;
using LeagueManager.League.Domain.ValuesObjects;
using OneOf;

namespace LeagueManager.Domain.Entities.Teams;
public sealed class Team : AgregateRoot<TeamId>
{
    public string Name { get; }

    public Address Address { get; }

    public Stadium Stadium { get; }

    public IEnumerable<PlayerId> PlayersIds => PlayersIds;

    private readonly List<PlayerId> _playersIds;

    private Team(TeamId id, string name, Address address, Stadium stadium) : base(id)
    {
        Address = address;
        Stadium = stadium;
        Name = name;
        _playersIds = [];
    }

    public static OneOf<Team, DomainValidationResult> Create(string name, Address address, Stadium stadium, IEnumerable<Team> existingTeams)
    {
        var result = ValidateBusinessRules(new ValidTeamNameRule(existingTeams, name));

        if (result.IsValid)
        {
            return new Team(new TeamId(Ulid.NewUlid()), name, address, stadium);
        }

        return result;
    }

    public DomainValidationResult AddPlayerAsync(Player player)
    {
        var result = new DomainValidationResult();
        _playersIds.Add(player.Id);

        return result;
    }
}

public sealed record TeamId(Ulid Value) : DomainId<Ulid>(Value);