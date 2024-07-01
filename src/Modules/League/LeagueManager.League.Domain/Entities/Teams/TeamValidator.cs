namespace LeagueManager.League.Domain.Entities.Teams;
internal class TeamValidator : ITeamValidator
{
    private readonly ITeamRepository _teamRepository;

    public TeamValidator(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<DomainValidationResult> ValidateTeamExistenceAsync(string teamName)
    {
        var teams = (await _teamRepository.GetAsync()).ToList();
        var result = new DomainValidationResult();
        if (teams.Any(x => x.Name.ToLower().Replace(" ", string.Empty) == teamName.ToLower().Replace(" ", string.Empty)))
            result.ValidationErrors.Add(string.Format(TeamMessages.TeamExistenceValidation, teamName));

        return result;
    }
}
