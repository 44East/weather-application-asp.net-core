namespace WeatherApp.Data.WeatherDataTemplate.DailyDetaiedTemplate
{
    public record Moon
    (
        DateTime? Rise, 
        int? EpochRise, 
        DateTime Set, 
        int EpochSet, 
        string Phase, 
        int Age
    );
}
