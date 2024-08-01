namespace SeriesManager.Responses
{
    public record EpisodeResponse(
        int id, 
        int EpisodeNumber, 
        string EpisodeName, 
        int SerieId, 
        string SerieName);
}
