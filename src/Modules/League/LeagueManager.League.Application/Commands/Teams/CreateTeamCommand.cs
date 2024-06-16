using LeagueManager.Shared.Abstractions.Domain;
using MediatR;

namespace LeagueManager.League.Application.Commands.Teams;
public record CreateTeamCommand() : IRequest<DomainValidationResult>;
