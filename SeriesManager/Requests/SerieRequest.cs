using SeriesManager_Console;

namespace SeriesManager.Requests
{
    public record SerieRequest(
        string serieName, 
        string serieGenre, 
        string serieDescription, 
        ICollection<PlatformRequest> Platforms = null, 
        ICollection<CountryRequest> Countries = null);
}
