namespace WeatherApp.Data.WeatherDataTemplate.DailyDetaiedTemplate
{
    public record Day
    (
        int Icon, 
        string IconPhrase, 
        bool HasPrecipitation, 
        string ShortPhrase, 
        string LongPhrase, 
        int PrecipitationProbability, 
        int ThunderstormProbability, 
        int RainProbability, 
        int SnowProbability, 
        int IceProbability, 
        Wind Wind, 
        WindGust WindGust, 
        TotalLiquid TotalLiquid, 
        Rain Rain, 
        Snow Snow, 
        Ice Ice, 
        double HoursOfPrecipitation, 
        double HoursOfRain, 
        double HoursOfSnow, 
        double HoursOfIce, 
        int CloudCover, 
        Evapotranspiration Evapotranspiration, 
        SolarIrradiance SolarIrradiance, 
        string PrecipitationType, 
        string PrecipitationIntensity
    );

}
