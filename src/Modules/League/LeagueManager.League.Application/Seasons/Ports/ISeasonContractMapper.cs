using LeagueManager.Domain.Entities.Seasons;
using LeagueManager.League.Domain.Entities.Seasons.TeamsInSeasons;

namespace LeagueManager.League.Application.Seasons.Ports;
public interface ISeasonContractMapper
{
    public SeasonDto Map(Season season);

    public IEnumerable<SeasonDto> Map(IEnumerable<Season> season);

    public TableDto Map(IEnumerable<TeamInSeason> teams);
}
