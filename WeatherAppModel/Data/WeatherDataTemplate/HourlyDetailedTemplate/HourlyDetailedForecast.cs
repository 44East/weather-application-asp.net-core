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
    /// The full weather forecast template for the daily forescts 
    /// </summary>
    /// <param name="DateTime"></param>
    /// <param name="EpochDateTime"></param>
    /// <param name="WeatherIcon"></param>
    /// <param name="IconPhrase"></param>
    /// <param name="HasPrecipitation"></param>
    /// <param name="IsDaylight"></param>
    /// <param name="Temperature"></param>
    /// <param name="RealFeelTemperature"></param>
    /// <param name="RealFeelTemperatureShade"></param>
    /// <param name="WetBulbTemperature"></param>
    /// <param name="DewPoint"></param>
    /// <param name="WindGust"></param>
    /// <param name="RelativeHumidity"></param>
    /// <param name="IndoorRelativeHumidity"></param>
    /// <param name="Visibility"></param>
    /// <param name="Ceiling"></param>
    /// <param name="UVIndex"></param>
    /// <param name="UVIndexText"></param>
    /// <param name="PrecipitationProbability"></param>
    /// <param name="ThunderstormProbability"></param>
    /// <param name="RainProbability"></param>
    /// <param name="SnowProbability"></param>
    /// <param name="IceProbability"></param>
    /// <param name="TotalLiquid"></param>
    /// <param name="Rain"></param>
    /// <param name="Snow"></param>
    /// <param name="Ice"></param>
    /// <param name="CloudCover"></param>
    /// <param name="Evapotranspiration"></param>
    /// <param name="SolarIrradiance"></param>
    /// <param name="MobileLink"></param>
    /// <param name="Link"></param>
    public record HourlyDetailedForecast
    (
       DateTime DateTime, // DateTime of the forecast, displayed in ISO8601 format.

       int EpochDateTime, //DateTime of the forecast, displayed as the number of
                          //seconds that have elapsed since January 1, 1970 (midnight UTC/GMT).

       int WeatherIcon, //DateTime of the forecast, displayed as the number of seconds that
                        //have elapsed since January 1, 1970 (midnight UTC/GMT).

       string IconPhrase, //Phrase description of the forecast associated with the WeatherIcon.
                          //Displayed in language specified by language code in URL

       bool HasPrecipitation, //Boolean value that indicates the presence of any type of precipitation for a given night.
                              //Displays true if precipitation is present.

       bool IsDaylight, //Specifies whether or not it is daylight (true=daylight, false=not daylight).

       HourlyTemperature Temperature, //Rounded value in specified units. May be NULL.

       RealFeelTemperature RealFeelTemperature, //Rounded value in specified units. May be NULL.
                                                //The RealFeel Temperature is an equation that takes into account many different
                                                //factors to determine how the temperature actually feels outside

       RealFeelTemperatureShade RealFeelTemperatureShade,//Rounded value in specified units. May be NULL.

       WetBulbTemperature WetBulbTemperature,//The temperature to which air may be cooled by evaporating water into
                                             //it at constant pressure until it reaches saturation.
                                             //Rounded value in specified units. May be NULL.

       DewPoint DewPoint,//The dew point is the temperature the air needs to be cooled
                         //to (at constant pressure) in order to achieve a relative humidity (RH) of 100%.

       WindGust WindGust,//A gust or wind gust is a brief increase in the speed of the wind, usually less than 20 seconds

       int RelativeHumidity,// Relative humidity, often expressed as a percentage, indicates a present state of absolute humidity
                            // relative to a maximum humidity given the same temperature.

       int IndoorRelativeHumidity,//(In buildings) Relative humidity, often expressed as a percentage,
                                  //indicates a present state of absolute humidity relative to
                                  //a maximum humidity given the same temperature.

       Visibility Visibility, //The visibility is the measure of the distance at which an object or light can be clearly discerned.

       Ceiling Ceiling, //Ceiling- The height of the lowest layer of clouds, when the sky is broken or overcast.

       int UVIndex,//Measure of the strength of the ultraviolet radiation from the sun. May be NULL.
       string UVIndexText, //Text associated with the UVIndex.

       int PrecipitationProbability,//Percent representing the probability of precipitation. May be NULL.

       int ThunderstormProbability,//Percent representing the probability of Thunderstorm. May be NULL.

       int RainProbability,//Percent representing the probability of rain. May be NULL.
       int SnowProbability,//Percent representing the probability of snow. May be NULL.
       int IceProbability,//Percent representing the probability of ice. May be NULL.

       TotalLiquid TotalLiquid,//Liquid precipitation
       Rain Rain,//Liquid precipitation
       Snow Snow,//Solid precipitation
       Ice Ice,//Solid precipitation

       int CloudCover,//Number representing the percentage of the sky that is covered by clouds. May be NULL.

       Evapotranspiration Evapotranspiration,//Evapotranspiration is the sum of all processes by which
                                             //water moves from the land surface to the atmosphere via evaporation and transpiration.

       SolarIrradiance SolarIrradiance,//The solar irradiance is the output of light energy from the entire disk of the Sun, measured at the Earth.

       string MobileLink, //Link to the hourly forecast for the requested location on AccuWeather`s mobile site.
       string Link //Link to the hourly forecast for the requested location on AccuWeather`s web site.
    );
}
