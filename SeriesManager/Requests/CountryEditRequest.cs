namespace SeriesManager.Requests
{
    public record CountryEditRequest (
        int id, 
        string countryName, 
        string language);
}
