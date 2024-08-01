using Microsoft.AspNetCore.Mvc;
using SerieManager.Shared.Data.BD;
using SeriesManager.Requests;
using SeriesManager.Responses;
using SeriesManager_Console;
using System;
using System.Diagnostics.Metrics;

namespace SeriesManager.EndPoints
{
    public static class SerieExtension
    {
        public static void AddEndPointsSerie(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("series").RequireAuthorization().WithTags("Serie");

            groupBuilder.MapGet("", ([FromServices] DAL<Serie> dal) =>
            {
                var serieList = dal.Read();
                if (serieList is null) return Results.NotFound();
                var serieResponseList = EntityListToResponseList(serieList);
                return Results.Ok(serieResponseList);
            });

            groupBuilder.MapGet("/{id}", ([FromServices] DAL<Serie> dal, int id) =>
            {
                var serie = dal.ReadBy(s => s.Id == id);
                if (serie is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(serie));
            });

            groupBuilder.MapPost("", 
                ([FromServices] DAL<Serie> dal, 
                [FromServices] DAL<Platform> dalPlatform, 
                [FromServices] DAL<Country> dalCountry,
                [FromBody] SerieRequest serieRequest) =>
            {
                var serie = new Serie(
                    serieRequest.serieName, 
                    serieRequest.serieGenre, 
                    serieRequest.serieDescription)
                {
                    Platforms = serieRequest.Platforms is not null ?
                    PlatformRequestConverter(serieRequest.Platforms, dalPlatform) :
                    new List<Platform>(),

                    Countries = serieRequest.Countries is not null ?
                    CountryRequestConverter(serieRequest.Countries, dalCountry) :
                    new List<Country>()
                };
                dal.Create(serie);
                return Results.Ok();
            });

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Serie> dal, int id) =>
            {
                var serie = dal.ReadBy(s => s.Id == id);
                if (serie is null) return Results.NotFound();
                dal.Delete(serie);
                return Results.NoContent();
            });

            groupBuilder.MapPut("", ([FromServices] DAL<Serie> dal, [FromBody] SerieEditRequest serieRequest) =>
            {
                var serieToEdit = dal.ReadBy(s => s.Id == serieRequest.id);
                if (serieToEdit is null) return Results.NotFound();
                serieToEdit.serieName = serieRequest.serieName;
                serieToEdit.serieGenre = serieRequest.serieGenre;
                serieToEdit.serieDescription = serieRequest.serieDescription;
                dal.Update(serieToEdit);
                return Results.Ok();
            });

            groupBuilder.MapGet("/platform/{platformId}", ([FromServices] DAL<Serie> dal, int platformId) =>
            {
                var series = dal.Read().Where(s => s.Platforms.Any(p => p.Id == platformId));
                if (series is null) return Results.NotFound();
                var serieResponseList = EntityListToResponseList(series);
                return Results.Ok(serieResponseList);
            });
        }

        private static ICollection<Country> CountryRequestConverter(ICollection<CountryRequest> countries, DAL<Country> dalCountry)
        {
            var countryList = new List<Country>();
            foreach (var countryLanguage in countries)
            {
                var entity = RequestToEntity(countryLanguage);
                var country = dalCountry.ReadBy(c => c.countryName.ToUpper().Equals(entity.countryName.ToUpper()) &&
                                                c.language.ToUpper().Equals(entity.language.ToUpper()));
                if (country is not null) countryList.Add(country);
                else countryList.Add(entity);
            }
            return countryList;
        }

        private static ICollection<SerieResponse> EntityListToResponseList(IEnumerable<Serie> serieList)
        {
            return serieList.Select(s => EntityToResponse(s)).ToList();
        }
        private static SerieResponse EntityToResponse(Serie serie)
        {
            return new SerieResponse(
                serie.Id, 
                serie.serieName, 
                serie.serieGenre,
                serie.serieDescription
                );
        }

        private static ICollection<Platform> PlatformRequestConverter(ICollection<PlatformRequest> platforms, DAL<Platform> dalPlatform)
        {
            var platformList = new List<Platform>();
            foreach (var platform in platforms)
            {
                var entity = RequestToEntity(platform);
                var plat = dalPlatform.ReadBy(p => p.platformName.ToUpper().Equals(entity.platformName.ToUpper()));
                if (plat is not null) platformList.Add(plat);
                else platformList.Add(entity);
            }
                return platformList;
        }
        private static Platform RequestToEntity(PlatformRequest p)
        {
            return new Platform() { platformName = p.platformName };
        }
        
        private static Country RequestToEntity(CountryRequest c)
        {
            return new Country() 
            { 
                countryName = c.countryName,
                language = c.language
            };
        }
    }
}