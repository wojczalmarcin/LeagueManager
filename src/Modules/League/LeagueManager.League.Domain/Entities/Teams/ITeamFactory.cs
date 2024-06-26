﻿using LeagueManager.Domain.Entities.Teams;
using LeagueManager.League.Domain.ValuesObjects;
using OneOf;

namespace LeagueManager.League.Domain.Entities.Teams;
public interface ITeamFactory
{
    Task<OneOf<Team, DomainValidationResult>> CreateAsync(string name, Address address, Stadium stadium);
}
