using FluentValidation.Results;
using LeagueManager.Domain.Entities.Seasons;
using LeagueManager.Domain.ValuesObjects;
using LeagueManager.League.Application;
using LeagueManager.Shared.Abstractions.Domain;
using MediatR;

namespace LeagueManager.Application.Seasons;
public record CreateSeasonCommand(
    DateTime StartDate,
    DateTime EndDate,
    IEnumerable<Guid> TeamsIds,
    string? SponsorName) : IRequest<ValidationResult>;

public class CreateSeasonCommandHandler : IRequestHandler<CreateSeasonCommand, ValidationResult>
{
    private readonly ISeasonFactory _seasonFactory;
    private readonly ISeasonRepository _seasonRepository;

    public CreateSeasonCommandHandler(ISeasonFactory seasonFactory, ISeasonRepository seasonRepository)
    {
        _seasonFactory = seasonFactory;
        _seasonRepository = seasonRepository;
    }

    public async Task<ValidationResult> Handle(CreateSeasonCommand request, CancellationToken cancellationToken)
    {
        var result = await _seasonFactory.CreateAsync(DateOnly.FromDateTime(request.StartDate), DateOnly.FromDateTime(request.EndDate),
            request.TeamsIds, request.SponsorName != null ? new Sponsor(request.SponsorName) : null);

        var validationResult = new DomainValidationResult();

        result.Switch(
            async season => await _seasonRepository.CreateAsync(season, cancellationToken),
            vr => validationResult = vr
            );
        return validationResult.Map();
    }
}