using Microsoft.EntityFrameworkCore;

namespace LeagueManager.League.Infrastructure.Persistence;
internal class LeagueDbContext(DbContextOptions<LeagueDbContext> options) : DbContext(options)
{
}
