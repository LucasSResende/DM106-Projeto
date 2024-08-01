using Microsoft.AspNetCore.Mvc;
using SerieManager.Shared.Data.BD;
using SeriesManager.Requests;
using SeriesManager.Responses;
using SeriesManager_Console;

namespace SerieManager.EndPoints
{
    public static class PlatformExtension
    {
        public static void AddEndPointsPlatform(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("platforms").RequireAuthorization().WithTags("Platform");

            groupBuilder.MapGet("", ([FromServices] DAL<Platform> dal) =>
            {
                var platformList = dal.Read();
                if (platformList is null) return Results.NotFound();
                var platformResponseList = EntityListToResponseList(platformList);
                return Results.Ok(platformResponseList);
            });

            groupBuilder.MapPost("", ([FromServices] DAL<Platform> dal, 
                [FromBody] PlatformRequest platformRequest) =>
            {
                dal.Create(RequestToEntity(platformRequest));
                return Results.Ok();
            });

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Platform> dal, int id) =>
            {
                var platform = dal.ReadBy(a => a.Id == id);
                if (platform is null) return Results.NotFound();
                dal.Delete(platform);
                return Results.NoContent();
            });
        }

        private static Platform RequestToEntity(PlatformRequest platformRequest)
        {
            return new Platform() { platformName = platformRequest.platformName };
        }

        private static ICollection<PlatformResponse> EntityListToResponseList(IEnumerable<Platform> platformList)
        {
            return platformList.Select(p => EntityToResponse(p)).ToList();
        }

        private static PlatformResponse EntityToResponse(Platform p)
        {
            return new PlatformResponse(p.Id, p.platformName);
        }
    }
}