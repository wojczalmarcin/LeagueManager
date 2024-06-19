using LeagueManager.Application.Seasons;
using LeagueManager.League.Application.Seasons;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace LeagueManager.League.WebApi.Endpoints;
internal static class SeasonEndpoints
{
    private const string EndpointName = "season";

    public static WebApplication UseSeasonEndpoints(this WebApplication app)
    {
        app.MapPost(EndpointName, async (CreateSeasonCommand seasonToCreate, ISender sender, CancellationToken ct = default) =>
        {
            var result = await sender.Send(seasonToCreate, ct);

            if (result.IsValid)
                return Results.Ok();

            return Results.ValidationProblem(result.ToDictionary());
        })
        .WithName("CreateSeason")
        .WithOpenApi();

        app.MapGet($"{EndpointName}/current", async (ISender sender, CancellationToken ct = default) =>
        {
            var query = new GetCurrentSeasonQuery();
            var season = await sender.Send(query, ct);

            return Results.Ok(season);
        })
        .WithName("GetCurrentSeason")
        .WithOpenApi();

        return app;
    }
}
