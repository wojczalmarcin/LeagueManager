using Elastic.Clients.Elasticsearch;

namespace LeagueManager.Statistics.Infrastructure.Persistence.Repositories;
internal class PlayerRepository
{
    private readonly ElasticsearchClient _client;

    private const string ElsIndex = "stats-player";

    public PlayerRepository(ElasticsearchClient client)
    {
        _client = client;
    }

    public async Task CreateAsync()
    {
        /*var existsResult = await _client.Indices.ExistsAsync(ElsIndex);
        if (!existsResult.Exists) {
            await _client.Indices.CreateAsync(ElsIndex);
        }
        var response = await _client.IndexAsync(new Exception(), i =>
        {
            i.Index(ElsIndex);
        });
        var response = await _client.IndexAsync(doc, ElsIndex);*/
    }
}
