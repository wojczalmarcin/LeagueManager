﻿using LeagueManager.Domain.Entities.Seasons;
using LeagueManager.Domain.ValuesObjects;
using LeagueManager.Shared.Abstractions.Domain;
using MediatR;

namespace LeagueManager.League.Application.Commands.Seasons;
public record CreateSeasonCommand(
    DateOnly StartDate,
    DateOnly EndDate,
    IEnumerable<Guid> TeamsIds, 
    string? SponsorName) : IRequest<DomainValidationResult>;

public class CreateSeasonCommandHandler : IRequestHandler<CreateSeasonCommand, DomainValidationResult>
{
    private readonly ISeasonFactory _seasonFactory;
    private readonly ISeasonRepository _seasonRepository;

    public CreateSeasonCommandHandler(ISeasonFactory seasonFactory, ISeasonRepository seasonRepository)
    {
        _seasonFactory = seasonFactory;
        _seasonRepository = seasonRepository;
    }

    public async Task<DomainValidationResult> Handle(CreateSeasonCommand request, CancellationToken cancellationToken)
    {
        var result = await _seasonFactory.CreateAsync(request.StartDate, request.EndDate, 
            request.TeamsIds, request.SponsorName != null ? new Sponsor(request.SponsorName) : null);

        var validationResult = new DomainValidationResult();

        result.Switch(
            async season => await _seasonRepository.CreateAsync(season),
            vr => validationResult = vr
            );
        return validationResult;
    }
}