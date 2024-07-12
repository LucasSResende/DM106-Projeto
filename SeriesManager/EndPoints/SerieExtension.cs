using Microsoft.AspNetCore.Mvc;
using SerieManager.Shared.Data.BD;
using SeriesManager.Requests;
using SeriesManager.Responses;
using SeriesManager_Console;

namespace SeriesManager.EndPoints
{
    public static class SerieExtension
    {
        public static void AddEndPointsSerie(this WebApplication app)
        {
            app.MapGet("/Series", ([FromServices] DAL<Serie> dal) =>
            {
                var serieList = dal.Read();
                if (serieList is null) return Results.NotFound();
                var serieResponseList = EntityListToResponseList(serieList);
                return Results.Ok(serieResponseList);
            });

            app.MapPost("/Series", ([FromBody] SerieRequest serieRequest, [FromServices] DAL<Serie> dal) =>
            {
                var serie = new Serie(serieRequest.serieName, serieRequest.serieGenre, serieRequest.serieDescription);
                dal.Create(serie);
                return Results.Ok();
            });

            app.MapDelete("/Series/{id}", ([FromServices] DAL<Serie> dal, int id) =>
            {
                var serie = dal.ReadBy(s => s.Id == id);
                if (serie is null) return Results.NotFound();
                dal.Delete(serie);
                return Results.NoContent();
            });

            app.MapPut("/Series", ([FromServices] DAL<Serie> dal, [FromBody] SerieEditRequest serieRequest) =>
            {
                var serieToEdit = dal.ReadBy(s => s.Id == serieRequest.id);
                if (serieToEdit is null) return Results.NotFound();
                serieToEdit.serieName = serieRequest.serieName;
                serieToEdit.serieGenre = serieRequest.serieGenre;
                serieToEdit.serieDescription = serieRequest.serieDescription;
                dal.Update(serieToEdit);
                return Results.Ok();
            });
        }

        private static ICollection<SerieResponse> EntityListToResponseList(IEnumerable<Serie> serieList)
        {
            return serieList.Select(s => EntityToResponse(s)).ToList();
        }
        private static SerieResponse EntityToResponse(Serie serie)
        {
            return new SerieResponse(serie.Id, serie.serieName, serie.serieGenre, serie.serieDescription);
        }
    }
}
