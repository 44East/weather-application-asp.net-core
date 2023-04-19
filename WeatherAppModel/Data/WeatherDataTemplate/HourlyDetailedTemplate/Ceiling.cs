using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public record Ceiling
    (
        double Value,
        string Unit,
        int UnitType
    );
}
