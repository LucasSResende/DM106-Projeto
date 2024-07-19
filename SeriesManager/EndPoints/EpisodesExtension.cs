using Microsoft.AspNetCore.Mvc;
using SerieManager.Shared.Data.BD;
using SeriesManager.Requests;
using SeriesManager.Responses;
using SeriesManager_Console;

namespace SeriesManager.EndPoints
{
    public static class EpisodesExtension
    {
        public static void AddEndPointsEpisode(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("episodes").RequireAuthorization().WithTags("Episode");

            groupBuilder.MapGet("", ([FromServices] DAL<Episode> dalEp) =>
            {
                var episodeList = dalEp.Read();
            if (episodeList is null) return Results.NotFound();
            var episodeResponseList = EntityListToResponseList(episodeList);
            return Results.Ok(episodeResponseList);
            });

            groupBuilder.MapPost("", ([FromBody] EpisodeRequest episodeRequest, [FromServices] DAL<Episode> dalEp) =>
            {
                dalEp.Create(new Episode(episodeRequest.EpisodeNumber, episodeRequest.EpisodeName));
                return Results.Ok();
            });

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Episode> dalEp, int id) =>
            {
                var episode = dalEp.ReadBy(e => e.Id == id);
                if (episode is null) return Results.NotFound();
                dalEp.Delete(episode);
                return Results.NoContent();
            });

            groupBuilder.MapPut("", ([FromServices] DAL<Episode> dalEp, [FromBody] EpisodeEditRequest episodeRequest) =>
            {
                var episodeToEdit = dalEp.ReadBy(e => e.Id == episodeRequest.id);
                if (episodeToEdit is null) return Results.NotFound();
                episodeToEdit.EpisodeNumber = episodeRequest.EpisodeNumber;
                episodeToEdit.EpisodeName = episodeRequest.EpisodeName;
                dalEp.Update(episodeToEdit);
                return Results.Ok();
            });
        }

        private static ICollection<EpisodeResponse> EntityListToResponseList(IEnumerable<Episode> episodeList)
        {
            return episodeList.Select(e => EntityToResponse(e)).ToList();
        }

        private static EpisodeResponse EntityToResponse(Episode episode)
        {
            return new EpisodeResponse(
                episode.Id,
                episode.EpisodeNumber,
                episode.EpisodeName,
                episode.Serie?.Id ?? 0,
                episode.Serie?.serieName ?? "No linked serie.");
        }
    }
}
