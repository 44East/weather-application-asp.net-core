using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    /// <summary>
    /// Basic data structure returned from the server https://www.accuweather.com/
    /// </summary>
    public record HourlyForecast
    (
       DateTime DateTime, 
       int EpochDateTime, 
       int WeatherIcon, 
       string IconPhrase, 
       bool HasPrecipitation, 
       bool IsDaylight, 
       HourlyTemperature Temperature, 
       int PrecipitationProbability,
       string MobileLink,
       string Link
    );
}
