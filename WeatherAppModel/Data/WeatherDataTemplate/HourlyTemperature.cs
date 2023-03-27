using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public record HourlyTemperature
    (
        double Temperature,
        string Unit,
        int UnitType
    );
}
