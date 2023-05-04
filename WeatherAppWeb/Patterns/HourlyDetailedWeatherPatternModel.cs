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
            /*--------------------------------------------------------------------- Location */
            CityName = cityInfo.EnglishName;
            CountryName = cityInfo.Country.EnglishName;
            CityKey = cityInfo.Key;
            /*--------------------------------------------------------------------- Temperature */
            TemperatureUnit = forecast.Temperature.Unit;
            Temperature = forecast.Temperature.Value;
            DewPointTemperature = forecast.DewPoint.Value;
            RealFeelTemperature = forecast.RealFeelTemperature.Value;
            TempratureFeelings = forecast.RealFeelTemperature.Phrase;
            //RealFeelTemperature = forecast.RealFeelTemperatureShade.Value; 
            /*--------------------------------------------------------------------- Wind */
            WindSpeed = forecast.Wind.Speed.Value;
            WindUnitOfMeasure = forecast.Wind.Speed.Unit;
            WindDirection = GetTheWindDirection(forecast.Wind.Direction.English);
            WindGustSpeed = forecast.WindGust.Speed.Value;
            /*--------------------------------------------------------------------- Precepitation */
            HasPrecipitation = forecast.HasPrecipitation;
            PrecipitationProbability = forecast.PrecipitationProbability;
            PrecipitationType = forecast.PrecipitationType;
            //If the forecast has precipitation, it checks the type of the precipitation and sets the value of total liquid. If precipitation doesn't exist it sets total value = 0; 
            TotalPrecipitationLiquid = forecast.HasPrecipitation ? GetTheTotalLiquid(forecast) : 0;
            TypeOfPrecipitationPropability = GetTypeOfPrecipitationPropability(forecast);
            /*--------------------------------------------------------------------- Sun */
            TimeOfNow = forecast.IsDaylight ? "Day" : "Night";
            IsDayLight = forecast.IsDaylight;
            UVIndex = forecast.UVIndex;
            UVIndexText = forecast.UVIndexText;
            SolarIrradiance = forecast.SolarIrradiance.Value;
            SolarIrradianceUnit = forecast.SolarIrradiance.Unit;
            /*---------------------------------------------------------------------*/
            Humidity = forecast.RelativeHumidity;
            ForecastMessage = forecast.IconPhrase;
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
        /// <summary>
        /// The dew point temperature 
        /// </summary>
        public double DewPointTemperature { get; init; }
        /// <summary>
        /// The unit of measurement
        /// </summary>
        public string TemperatureUnit { get; init; }
        /// <summary>
        /// Message about feeling of the temperature
        /// </summary>
        public string TempratureFeelings { get; init; }
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
        public string PrecipitationType { get; init; }
        /// <summary>
        /// Rounded value in specified units
        /// </summary>
        public double TotalPrecipitationLiquid { get; init; }
        /// <summary>
        /// Sets the total value of the precipitation liquid and unit type of measurement 
        /// </summary>
        /// <param name="forecast">The current forecast instance</param>
        /// <returns>A <see cref="double"/> value of precipitation liquid </returns>
        private double GetTheTotalLiquid(HourlyDetailedForecast forecast)
        {
            
            switch (forecast.PrecipitationType?.ToLower()) 
            {
                case "snow":
                    LiquidUnitOfMeasure = forecast.Snow.Unit;
                    return forecast.Snow.Value;
                case "rain": 
                    LiquidUnitOfMeasure = forecast.Rain.Unit;
                    return forecast.Rain.Value;
                case "ice": 
                    LiquidUnitOfMeasure = forecast.Ice.Unit;
                    return forecast.Ice.Value;
                default:
                    LiquidUnitOfMeasure = forecast.TotalLiquid.Unit;
                    return forecast.TotalLiquid.Value;                     
            }
        }
        /// <summary>
        /// The unit of measurement
        /// </summary>
        public string LiquidUnitOfMeasure { get; private set; }
        /// <summary>
        /// Obtain the type of precipitation if available.
        /// </summary>
        /// <param name="forecast">Current forecast instance</param>
        /// <returns>Type of precipitation</returns>
        private string GetTypeOfPrecipitationPropability(HourlyDetailedForecast forecast)
        {
            if (forecast.IceProbability > 0)
            {
                return "Ice rain";
            }
            else if (forecast.RainProbability > 0)
            {
                return "Rain";
            }
            else if (forecast.SnowProbability > 0)
            {
                return "Snow";
            }
            else
                return string.Empty;
        }
        /// <summary>
        /// The type of precipitation
        /// </summary>
        public string TypeOfPrecipitationPropability { get; set; }


        #endregion

        #region Sun
        /// <summary>
        /// Value of the strength of the ultraviolet radiation from the sun
        /// </summary>
        public int UVIndex { get; init; }
        /// <summary>
        /// A text status of the UV Index  
        /// </summary>
        public string UVIndexText { get; init; }
        /// <summary>
        /// Indicates whether it is the daylight or not
        /// </summary>
        public bool IsDayLight { get; init; }
        /// <summary>
        /// Gets the time of a day.
        /// </summary>
        public string TimeOfNow { get; init; }
        /// <summary>
        /// The value of the solar irradiance in W/m²
        /// </summary>
        public double SolarIrradiance { get; set; }
        /// <summary>
        /// Type of the measurement unit of the solar irradiance
        /// </summary>
        public string SolarIrradianceUnit { get; set; }
        #endregion

        /// <summary>
        /// The Relative Humidity in the percent value
        /// </summary>
        public int Humidity { get; set; }
        /// <summary>
        /// The forecast message with the weather review.
        /// </summary>
        public string ForecastMessage { get; init; }
        
        /// <summary>
        /// Contains the weather icon file name.
        /// </summary>
        public string WeatherIcon { get; init; }
        
    }
}
