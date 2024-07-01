namespace LeagueManager.League.Domain.Entities.Teams;
public interface ITeamValidator
{
    Task<DomainValidationResult> ValidateTeamExistenceAsync(string teamName);
}
