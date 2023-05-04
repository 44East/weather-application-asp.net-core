
namespace WeatherApp
{
    /// <summary>
    /// Basic data structure returned from the server https://www.accuweather.com/
    /// </summary>
    public record DailyForecast(DateTime Date, int EpochDate, Temperature Temperature, Day Day, Night Night, List<string> Sources, string MobileLink, string Link);
}
