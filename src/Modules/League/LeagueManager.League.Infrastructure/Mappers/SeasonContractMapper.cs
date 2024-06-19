using LeagueManager.Domain.Entities.Seasons;
using LeagueManager.League.Application.Seasons;
using Riok.Mapperly.Abstractions;

namespace LeagueManager.League.Infrastructure.Mappers;

[Mapper]
internal partial class SeasonContractMapper : ISeasonContractMapper
{
    public partial SeasonDto Map(Season season);
    public partial IEnumerable<SeasonDto> Map(IEnumerable<Season> season);
}
