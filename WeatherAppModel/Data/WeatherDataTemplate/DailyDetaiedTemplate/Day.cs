namespace WeatherApp.Data.WeatherDataTemplate.DailyDetaiedTemplate
{
    /// <summary>
    /// Represents weather forecast information for a day time period.
    /// </summary>
    /// <param name="Icon">The weather icon.</param>
    /// <param name="IconPhrase">The description of the weather icon.</param>
    /// <param name="HasPrecipitation">Indicates if precipitation is expected.</param>
    /// <param name="ShortPhrase">A short description of the weather conditions.</param>
    /// <param name="LongPhrase">A detailed description of the weather conditions.</param>
    /// <param name="PrecipitationProbability">The probability of precipitation.</param>
    /// <param name="ThunderstormProbability">The probability of thunderstorms.</param>
    /// <param name="RainProbability">The probability of rain.</param>
    /// <param name="SnowProbability">The probability of snow.</param>
    /// <param name="IceProbability">The probability of ice.</param>
    /// <param name="Wind">The wind speed.</param>
    /// <param name="WindGust">The wind gust speed.</param>
    /// <param name="TotalLiquid">The total amount of liquid precipitation.</param>
    /// <param name="Rain">The amount of rain precipitation.</param>
    /// <param name="Snow">The amount of snow precipitation.</param>
    /// <param name="Ice">The amount of ice precipitation.</param>
    /// <param name="HoursOfPrecipitation">The duration of precipitation in hours.</param>
    /// <param name="HoursOfRain">The duration of rain precipitation in hours.</param>
    /// <param name="HoursOfSnow">The duration of snow precipitation in hours.</param>
    /// <param name="HoursOfIce">The duration of ice precipitation in hours.</param>
    /// <param name="CloudCover">The cloud cover percentage.</param>
    /// <param name="Evapotranspiration">The evapotranspiration value.</param>
    /// <param name="SolarIrradiance">The solar irradiance value.</param>
    /// <param name="PrecipitationType">The type of precipitation.</param>
    /// <param name="PrecipitationIntensity">The intensity of precipitation.</param>
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
