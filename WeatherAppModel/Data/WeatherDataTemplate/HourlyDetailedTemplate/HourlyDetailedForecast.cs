using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WeatherApp
{
    /// <summary>
    /// The full weather forecast template for the daily forecasts.
    /// </summary>
    /// <param name="DateTime">DateTime of the forecast, displayed in ISO8601 format.</param>
    /// <param name="EpochDateTime">DateTime of the forecast, displayed as the number of seconds that have elapsed since January 1, 1970 (midnight UTC/GMT).</param>
    /// <param name="WeatherIcon">DateTime of the forecast, displayed as the number of seconds that have elapsed since January 1, 1970 (midnight UTC/GMT).</param>
    /// <param name="IconPhrase">Phrase description of the forecast associated with the WeatherIcon. Displayed in language specified by language code in URL.</param>
    /// <param name="HasPrecipitation">Boolean value that indicates the presence of any type of precipitation for a given night. Displays true if precipitation is present.</param>
    /// <param name="IsDaylight">Specifies whether or not it is daylight (true=daylight, false=not daylight).</param>
    /// <param name="Temperature">Rounded value in specified units. May be NULL.</param>
    /// <param name="RealFeelTemperature">Rounded value in specified units. May be NULL. The RealFeel Temperature is an equation that takes into account many different factors to determine how the temperature actually feels outside.</param>
    /// <param name="RealFeelTemperatureShade">Rounded value in specified units. May be NULL.</param>
    /// <param name="WetBulbTemperature">The temperature to which air may be cooled by evaporating water into it at constant pressure until it reaches saturation. Rounded value in specified units. May be NULL.</param>
    /// <param name="DewPoint">The dew point is the temperature the air needs to be cooled to (at constant pressure) in order to achieve a relative humidity (RH) of 100%.</param>
    /// <param name="WindGust">A gust or wind gust is a brief increase in the speed of the wind, usually less than 20 seconds.</param>
    /// <param name="RelativeHumidity">Relative humidity, often expressed as a percentage, indicates a present state of absolute humidity relative to a maximum humidity given the same temperature.</param>
    /// <param name="IndoorRelativeHumidity">(In buildings) Relative humidity, often expressed as a percentage, indicates a present state of absolute humidity relative to a maximum humidity given the same temperature.</param>
    /// <param name="Visibility">The visibility is the measure of the distance at which an object or light can be clearly discerned.</param>
    /// <param name="Ceiling">The height of the lowest layer of clouds, when the sky is broken or overcast.</param>
    /// <param name="UVIndex">Measure of the strength of the ultraviolet radiation from the sun. May be NULL.</param>
    /// <param name="UVIndexText">Text associated with the UVIndex.</param>
    /// <param name="PrecipitationProbability">Percent representing the probability of precipitation. May be NULL.</param>
    /// <param name="ThunderstormProbability">Percent representing the probability of Thunderstorm. May be NULL.</param>
    /// <param name="RainProbability">Percent representing the probability of rain. May be NULL.</param>
    /// <param name="SnowProbability">Percent representing the probability of snow. May be NULL.</param>
    /// <param name="IceProbability">Percent representing the probability of ice. May be NULL.</param>
    /// <param name="TotalLiquid">Liquid precipitation.</param>
    /// <param name="Rain">Liquid precipitation.</param>
    /// <param name="Snow">Liquid precipitation.</param>
    /// <param name="Ice">Liquid precipitation.</param>
    /// <param name="CloudCover">Number representing the percentage of the sky that is covered by clouds. May be NULL.</param>
    /// <param name="Evapotranspiration">Evapotranspiration is the sum of all processes by which water moves from the land surface to the atmosphere via evaporation and transpiration.</param>
    /// <param name="SolarIrradiance">The solar irradiance is the output of light energy from the entire disk of the Sun, measured at the Earth.</param>
    /// <param name="MobileLink">Link to the hourly forecast for the requested location on AccuWeather`s mobile site.</param>
    /// <param name="Link">Link to the hourly forecast for the requested location on AccuWeather`s web site.</param>
    public record HourlyDetailedForecast
    (
       DateTime DateTime, 

       int EpochDateTime, 

       int WeatherIcon, 

       string IconPhrase, 

       bool HasPrecipitation, 

       bool IsDaylight, 

       HourlyTemperature Temperature, 

       RealFeelTemperature RealFeelTemperature, 

       RealFeelTemperatureShade RealFeelTemperatureShade,

       WetBulbTemperature WetBulbTemperature,

       DewPoint DewPoint,

       WindGust WindGust,

       int RelativeHumidity,

       int IndoorRelativeHumidity,

       Visibility Visibility, 

       Ceiling Ceiling, 
       int UVIndex,
       string UVIndexText, 

       int PrecipitationProbability,

       int ThunderstormProbability,

       int RainProbability,
       int SnowProbability,
       int IceProbability,

       TotalLiquid TotalLiquid,
       Rain Rain,
       Snow Snow,
       Ice Ice,

       int CloudCover,

       Evapotranspiration Evapotranspiration,

       SolarIrradiance SolarIrradiance,

       string MobileLink, 
       string Link 
    );
}
