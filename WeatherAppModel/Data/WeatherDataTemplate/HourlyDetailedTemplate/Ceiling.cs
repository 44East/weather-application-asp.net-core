using WeatherApp.Data.WeatherDataTemplate.HourlyDetailedTemplate;

namespace WeatherApp.Data.WeatherDataTemplate.HourlyDetailedTemplate
{
    public record Ceiling
    (
        double Value,
        string Unit,
        int UnitType
    );
}
