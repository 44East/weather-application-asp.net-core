using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
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
