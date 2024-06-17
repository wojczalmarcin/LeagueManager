using LeagueManager.League.Application.Commands.Seasons;
using MediatR;
using Microsoft.AspNetCore.Builder;

namespace LeagueManager.League.WebApi.Endpoints;
internal static class SeasonEndpoints
{
    private const string EndpointName = "season";

    public static WebApplication UseSeasonEndpoints(this WebApplication app)
    {
        app.MapPost(EndpointName, async (CreateSeasonCommand seasonToCreate, ISender sender) =>
        {
            await sender.Send(seasonToCreate);
            return;
        })
        .WithName("CreateSeason")
        .WithOpenApi();
        return app;
    }
}
