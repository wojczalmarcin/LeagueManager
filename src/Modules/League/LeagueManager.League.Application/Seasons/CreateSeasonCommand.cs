using FluentValidation.Results;
using LeagueManager.Domain.Entities.Seasons;
using LeagueManager.Domain.Entities.Teams;
using LeagueManager.Domain.ValuesObjects;
using LeagueManager.League.Application;
using LeagueManager.League.Application.Seasons.Ports;
using MediatR;

namespace LeagueManager.Application.Seasons;
public record CreateSeasonCommand(
    DateTime StartDate,
    DateTime EndDate,
    IEnumerable<TeamId> TeamsIds,
    string? SponsorName) : IRequest<ValidationResult>;

public class CreateSeasonCommandHandler : IRequestHandler<CreateSeasonCommand, ValidationResult>
{
    private readonly ISeasonRepository _seasonRepository;

    public CreateSeasonCommandHandler(ISeasonRepository seasonRepository)
    {
        _seasonRepository = seasonRepository;
    }

    public async Task<ValidationResult> Handle(CreateSeasonCommand request, CancellationToken cancellationToken)
    {
        var allSeasons = await _seasonRepository.GetAsync(cancellationToken);
        var result = Season.Create(DateOnly.FromDateTime(request.StartDate), DateOnly.FromDateTime(request.EndDate),
            request.TeamsIds, allSeasons, request.SponsorName != null ? new Sponsor(request.SponsorName) : null, cancellationToken);

        var finalResult = new ValidationResult();

        result.Switch(
            async season => await _seasonRepository.CreateAsync(season, cancellationToken),
            vr => finalResult = vr.Map()
            );
        return finalResult;
    }
}