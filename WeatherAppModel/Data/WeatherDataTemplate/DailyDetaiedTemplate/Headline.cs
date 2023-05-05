namespace WeatherApp.Data.WeatherDataTemplate.DailyDetaiedTemplate
{
    public record Headline
    (
        DateTime EffectiveDate, 
        int EffectiveEpochDate, 
        int Severity, 
        string Text, 
        string Category, 
        DateTime EndDate, 
        int EndEpochDate, 
        string MobileLink, 
        string Link
    );
}
