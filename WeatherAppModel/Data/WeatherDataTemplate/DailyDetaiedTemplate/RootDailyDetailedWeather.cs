namespace WeatherApp.Data.WeatherDataTemplate.DailyDetaiedTemplate
{

    /// <summary>
    /// Represents detailed weather information for a specific day.
    /// </summary>
    /// <param name="Headline">The weather headline for the day.</param>
    /// <param name="DailyForecasts">The list of daily forecasts.</param>
    public record RootDailyDetailedWeather(Headline Headline, List<DetailedDailyForecast> DailyForecasts);

}
