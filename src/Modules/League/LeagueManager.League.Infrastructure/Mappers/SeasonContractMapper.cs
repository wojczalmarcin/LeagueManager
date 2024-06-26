using LeagueManager.Domain.Entities.Seasons;
using LeagueManager.League.Application.Seasons;
using LeagueManager.League.Domain.Entities.TeamsInSeasons;
using Riok.Mapperly.Abstractions;

namespace LeagueManager.League.Infrastructure.Mappers;

[Mapper]
internal partial class SeasonContractMapper : ISeasonContractMapper
{
    public partial SeasonDto Map(Season season);
    public partial IEnumerable<SeasonDto> Map(IEnumerable<Season> season);

    public TableDto Map(IEnumerable<TeamInSeason> teams)
    {
        return new TableDto()
        {
            Teams = MapTeams(teams)
        };
    }


    [MapProperty([nameof(TeamInSeason.MatechesPoints), nameof(TeamInSeason.MatechesPoints.PointsFor)], [nameof(TeamInTableDto.GoalsFor)])]
    [MapProperty([nameof(TeamInSeason.MatechesPoints), nameof(TeamInSeason.MatechesPoints.PointsAgainst)], [nameof(TeamInTableDto.GoalsAgainst)])]
    [MapProperty([nameof(TeamInSeason.TeamId)], [nameof(TeamInTableDto.Team), nameof(TeamInTableDto.Team.Id)])]
    private partial IEnumerable<TeamInTableDto> MapTeams(IEnumerable<TeamInSeason> season);
}
