using FluentValidation.Results;
using MediatR;

namespace LeagueManager.League.Application.Teams;
public record CreateTeamCommand() : IRequest<ValidationResult>;
