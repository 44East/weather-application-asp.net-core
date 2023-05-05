namespace WeatherApp.Data.WeatherDataTemplate.HourlyDetailedTemplate
{
    public record RealFeelTemperature
    (
        double Value,
        string Unit,
        int UnitType,
        string Phrase
    );
}
