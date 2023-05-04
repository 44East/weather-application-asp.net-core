
namespace WeatherApp
{
    /// <summary>
    /// Basic data structure returned from the server https://www.accuweather.com/
    /// </summary>
    public record DailyRootWeather(Headline Headline, List<DailyForecast> DailyForecasts);
}
