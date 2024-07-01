using LeagueManager.Domain.Entities.Seasons;
using LeagueManager.League.Domain.Entities.Teams;
using MediatR;

namespace LeagueManager.League.Application.Seasons;
public sealed class GetSeasonTableQuery : IRequest<TableDto>
{
}

public sealed class GetSeasonTableQueryHandler : IRequestHandler<GetSeasonTableQuery, TableDto>
{
    private readonly ISeasonRepository _seasonRepository;

    private readonly ISeasonContractMapper _seasonContractMapper;

    private readonly ITeamRepository _teamRepository;

    public GetSeasonTableQueryHandler(ISeasonRepository seasonRepository,
        ISeasonContractMapper seasonContractMapper, ITeamRepository teamRepository)
    {
        _seasonRepository = seasonRepository;
        _seasonContractMapper = seasonContractMapper;
        _teamRepository = teamRepository;
    }

    public async Task<TableDto> Handle(GetSeasonTableQuery request,
        CancellationToken cancellationToken)
    {
        var season = await _seasonRepository.GetCurrentAsync(cancellationToken);

        var table = _seasonContractMapper.Map(season.Teams);
        var teams = await _teamRepository.GetAsync(season.Teams.Select(x => x.TeamId));

        foreach (var item in table.Teams)
        {
            item.Team.Name = teams.First(x => x.Id.Value == item.Team.Id).Name;
        }
        return table;
    }
}