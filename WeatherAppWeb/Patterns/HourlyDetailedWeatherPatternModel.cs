using WeatherApp;

namespace WeatherAppWeb.Patterns
{

    /// <summary>
    /// Represents a model for detailed hourly weather patterns.
    /// </summary>
    public class HourlyDetailedWeatherPatternModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HourlyDetailedWeatherPatternModel"/>  class.
        /// </summary>
        /// <param name="forecast">The hourly forecast data.</param>
        /// <param name="cityInfo">The basic information of the city.</param>
        public HourlyDetailedWeatherPatternModel(HourlyDetailedForecast forecast, RootBasicCityInfo cityInfo)
        {
            CityName = cityInfo.EnglishName;
            CountryName = cityInfo.Country.EnglishName;
            CityKey = cityInfo.Key;

            Temperature = forecast.Temperature.Value;
            RealFeelTemperature = forecast.RealFeelTemperature.Value;
            //RealFeelTemperature = forecast.RealFeelTemperatureShade.Value; 

            WindSpeed = forecast.Wind.Speed.Value;
            WindUnitOfMeasure = forecast.Wind.Speed.Unit;
            WindDirection = GetTheWindDirection(forecast.Wind.Direction.English);
            WindGustSpeed = forecast.WindGust.Speed.Value;

            HasPrecipitation = forecast.HasPrecipitation;
            PrecipitationProbability = forecast.PrecipitationProbability;
            PrecipitationType = forecast.PrecipitationType;

            IsDayLight = forecast.IsDaylight;
            
            ForecastMessage = forecast.IconPhrase;
            
            TimeOfNow = forecast.IsDaylight ? "day" : "night";
            WeatherIcon = forecast.WeatherIcon.ToString() + ".png";
        }

        #region Location
        /// <summary>
        /// The name of the current city.
        /// </summary>
        public string CityName { get; init; }
        /// <summary>
        /// The name of the current country.
        /// </summary>
        public string CountryName { get; init; }
        /// <summary>
        /// The key of the current city.
        /// </summary>
        public string CityKey { get; init; }
        #endregion

        #region Temperature
        /// <summary>
        /// The temperature value.
        /// </summary>
        public double Temperature { get; init; }
        /// <summary>
        /// The real feel temperature value.
        /// </summary>
        public double RealFeelTemperature { get; init; }
        #endregion

        #region Wind 
        /// <summary>
        /// The wind speed in the specified value.
        /// </summary>
        public double WindSpeed { get; init; }
        /// <summary>
        /// The unit of measurement
        /// </summary>
        public string WindUnitOfMeasure { get; set; }
        /// <summary>
        /// The direction of the wind, it contains the full name of the direction.
        /// </summary>
        public string WindDirection { get; init; }
        /// <summary>
        /// Sets the full name of the direction ot the wind.
        /// </summary>
        /// <param name="shortName">Short system name of the direction</param>
        /// <returns>A full name in <see cref="string"/> format for <see cref="WindDirection"/> property</returns>
        private string GetTheWindDirection(string shortName)
        {
            switch (shortName)
            {
                case "N":
                    return "North";
                case "NNE":
                    return "North-North-East";
                case "NE":
                    return "North-East";
                case "ENE":
                    return "East-North-East";
                case "E":
                    return "East";
                case "ESE":
                    return "East-South-East";
                case "SE":
                    return "South-East";
                case "SSE":
                    return "South-South-East";
                case "S":
                    return "South";
                case "SSW":
                    return "South-South-West";
                case "SW":
                    return "South-West";
                case "WSW":
                    return "West-South-West";
                case "W":
                    return "West";
                case "WNW":
                    return "West-North-West";
                case "NW":
                    return "North-West";
                case "NNW":
                    return "North-North-West";
                default:
                    return "Calm";
            }
        }
        /// <summary>
        /// The wind gusts speed in the specified value.
        /// </summary>
        public double WindGustSpeed { get; init; }

        #endregion


        #region Precipitation
        /// <summary>
        /// Indicates whether it has precipitation or not
        /// </summary>
        public bool HasPrecipitation { get; init; }

        /// <summary>
        /// The probability of precipitation
        /// </summary>
        public int PrecipitationProbability { get; init; }
        /// <summary>
        /// Declare type of precipitation (Rain, Snow, Ice or mixed)
        /// </summary>
        public string PrecipitationType { get; set; }
        #endregion


        /// <summary>
        /// Indicates whether it is daylight or not
        /// </summary>
        public bool IsDayLight { get; init; }

        

        

        /// <summary>
        /// The forecast message with the weather review.
        /// </summary>
        public string ForecastMessage { get; init; }

        /// <summary>
        /// Gets the time of day.
        /// </summary>
        public string TimeOfNow { get; init; }

        /// <summary>
        /// Contains the weather icon file name.
        /// </summary>
        public string WeatherIcon { get; init; }
        
    }
}
