using LeagueManager.Statistics.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using LeagueManager.Shared.Infrastructure.Configuration;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace LeagueManager.Statistics.Infrastructure;
public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var databaseConfig = services.GetSection<StatisticsDatabaseConfig>("StatisticsDatabase");
        var elsClient = new ElasticsearchClient(new ElasticsearchClientSettings(
            new StaticNodePool(databaseConfig.Nodes.Select(x => new Uri(x)).ToArray())));
        services.AddSingleton(elsClient);
        return services;
    }

}
