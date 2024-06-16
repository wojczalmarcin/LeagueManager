using LeagueManager.Shared.Abstractions.Domain;

namespace LeagueManager.League.Domain.Entities.Teams;
public interface ITeamValidator
{
    Task<DomainValidationResult> ValidateTeamExistenceAsync(string teamName);
}
