using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public record Direction
    (
        int Degrees,
        string Localized,
        string English
    );

}
