using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueManager.Shared.Infrastructure.Configuration;
public static class Extensions
{
    public static T GetSection<T>(this IServiceCollection services, string sectionName) where T : new()
    {
        var o = new T();
        using var serviceProvider = services.BuildServiceProvider();
        var c = serviceProvider.GetRequiredService<IConfiguration>();
        c.GetSection(sectionName).Bind(o);
        return o;
    }
}