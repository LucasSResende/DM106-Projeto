namespace SeriesManager.Responses
{
    public record SerieResponse(
        int id, 
        string serieName, 
        string serieGenre, 
        string serieDescription);
}
