using Microsoft.AspNetCore.Mvc;
using SerieManager.Shared.Data.BD;
using SeriesManager.Requests;
using SeriesManager.Responses;
using SeriesManager_Console;

namespace SeriesManager.EndPoints
{
    public static class CountryExtension
    {
        public static void AddEndPointsCountry(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("countries").RequireAuthorization().WithTags("Country");

            groupBuilder.MapGet("", ([FromServices] DAL<Country> dalCountry) =>
            {
                var countryList = dalCountry.Read();
                if (countryList is null) return Results.NotFound();
                var countryResponseList = EntityListToResponseList(countryList);
                return Results.Ok(countryResponseList);
            });

            groupBuilder.MapPost("", (
                [FromBody] CountryRequest countryRequest, 
                [FromServices] DAL<Country> dalCountry) =>
            {
                dalCountry.Create(new Country(countryRequest.countryName, countryRequest.language));
                return Results.Ok();
            });

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Country> dalCountry, int id) =>
            {
                var country = dalCountry.ReadBy(c => c.Id == id);
                if (country is null) return Results.NotFound();
                dalCountry.Delete(country);
                return Results.NoContent();
            });

            groupBuilder.MapPut("", ([FromServices] DAL<Country> dalCountry, [FromBody] CountryEditRequest countryEditRequest) =>
            {
                var countryToEdit = dalCountry.ReadBy(e => e.Id == countryEditRequest.id);
                if (countryToEdit is null) return Results.NotFound();
                countryToEdit.countryName = countryEditRequest.countryName;
                countryToEdit.countryName = countryEditRequest.language;
                dalCountry.Update(countryToEdit);
                return Results.Ok();
            });
        }

        private static Country RequestToEntity(CountryRequest countryRequest)
        {
            return new Country() 
            { 
                countryName = countryRequest.countryName,
                language = countryRequest.language
            };
        }

        private static ICollection<CountryResponse> EntityListToResponseList(IEnumerable<Country> countryList)
        {
            return countryList.Select(c => EntityToResponse(c)).ToList();
        }

        private static CountryResponse EntityToResponse(Country c)
        {
            return new CountryResponse(
                c.Id,
                c.countryName,
                c.language);
        }
    }
}

