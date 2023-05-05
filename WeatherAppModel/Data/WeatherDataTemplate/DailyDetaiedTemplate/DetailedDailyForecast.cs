

namespace WeatherApp.Data.WeatherDataTemplate.DailyDetaiedTemplate
{
    public record DetailedDailyForecast
    (
        DateTime Date, 
        int EpochDate, 
        Sun Sun, 
        Moon Moon, 
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
