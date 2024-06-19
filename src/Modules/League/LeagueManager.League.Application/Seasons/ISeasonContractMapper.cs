using LeagueManager.Domain.Entities.Seasons;

namespace LeagueManager.League.Application.Seasons;
public interface ISeasonContractMapper
{
    public SeasonDto Map(Season season);

    public IEnumerable<SeasonDto> Map(IEnumerable<Season> season);
}
