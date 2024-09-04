using LeagueManager.League.Application.Seasons.Ports;
using MediatR;

namespace LeagueManager.League.Application.Seasons;
public sealed class GetCurrentSeasonQuery : IRequest<SeasonDto>
{
}

public class GetCurrentSeasonQueryHandler : IRequestHandler<GetCurrentSeasonQuery, SeasonDto>
{
    private readonly ISeasonRepository _seasonRepository;

    private readonly ISeasonContractMapper _seasonContractMapper;

    public GetCurrentSeasonQueryHandler(ISeasonRepository seasonRepository, ISeasonContractMapper seasonContractMapper)
    {
        _seasonRepository = seasonRepository;
        _seasonContractMapper = seasonContractMapper;
    }

    public async Task<SeasonDto> Handle(GetCurrentSeasonQuery request,
        CancellationToken cancellationToken)
    {
        var season = await _seasonRepository.GetCurrentAsync(cancellationToken);

        return _seasonContractMapper.Map(season);
    }
}
