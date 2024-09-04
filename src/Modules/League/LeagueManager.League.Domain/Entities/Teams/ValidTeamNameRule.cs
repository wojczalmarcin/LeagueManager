using LeagueManager.Domain.Entities.Teams;

namespace LeagueManager.League.Domain.Entities.Teams;
public sealed class ValidTeamNameRule(IEnumerable<Team> existingTeams, string teamName) : IDomainValidator
{
    private readonly IEnumerable<Team> existingTeams = existingTeams;
    private readonly string teamName = teamName;

    public DomainValidationResult Validate()
    {
        var result = new DomainValidationResult();
        if (existingTeams.Any(x => x.Name.ToLower().Replace(" ", string.Empty) == teamName.ToLower().Replace(" ", string.Empty)))
            result.ValidationErrors.Add(string.Format(TeamMessages.TeamExistenceValidation, teamName));

        return result;
    }
}
