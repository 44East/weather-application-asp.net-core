namespace WeatherApp.Data.WeatherDataTemplate.HourlyDetailedTemplate
{
    public record HourlyTemperature
    (
        double Value,
        string Unit,
        int UnitType
    );
}
