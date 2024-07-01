using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Statistics.Application.Contracts;
public class PlayerDto
{
    public Guid Id { get; }

    public string Name { get; }

    public string Surname { get; }
}
