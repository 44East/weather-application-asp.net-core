

namespace WeatherApp.Data.WeatherDataTemplate.DailyDetaiedTemplate
{
    /// <summary>
    /// Represents daily weather information.
    /// </summary>
    /// <param name="Date">The date of the weather information.</param>
    /// <param name="EpochDate">The epoch date of the weather information.</param>
    /// <param name="Sun">The sun information.</param>
    /// <param name="Moon">The moon information.</param>
    /// <param name="Temperature">The temperature information.</param>
    /// <param name="RealFeelTemperature">The "Real Feel" temperature information.</param>
    /// <param name="RealFeelTemperatureShade">The "Real Feel" temperature in shade information.</param>
    /// <param name="HoursOfSun">The number of hours of sun.</param>
    /// <param name="DegreeDaySummary">The degree day summary.</param>
    /// <param name="AirAndPollen">The air and pollen information.</param>
    /// <param name="Day">The daily forecast for the day.</param>
    /// <param name="Night">The daily forecast for the night.</param>
    /// <param name="Sources">The sources of the weather information.</param>
    /// <param name="MobileLink">The mobile link for more details.</param>
    /// <param name="Link">The link for more details.</param>
    public record DetailedDailyForecast
    (
        DateTime Date, 
        int EpochDate, 
        Sun Sun, 
        Moon? Moon, 
        Temperature Temperature, 
        RealFeelTemperature RealFeelTemperature, 
        RealFeelTemperatureShade RealFeelTemperatureShade, 
        double HoursOfSun, 
        DegreeDaySummary DegreeDaySummary, 
        List<AirAndPollen> AirAndPollen, 
        Day Day, 
        Night Night, 
        List<string> Sources, 
        string MobileLink, 
        string Link
    );
}
