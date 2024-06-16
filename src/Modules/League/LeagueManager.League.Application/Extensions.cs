using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueManager.League.Application;
public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Extensions).Assembly);
        return services;
    }
}
