using WeatherApp;

namespace WeatherAppWeb
{
    /// <summary>
    /// Represents a model for hourly weather patterns.
    /// </summary>
    public class HourlyWeatherPatternModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HourlyWeatherPatternModel"/>  class.
        /// </summary>
        /// <param name="forecast">The hourly forecast data.</param>
        /// <param name="cityInfo">The basic information of the city.</param>
        public HourlyWeatherPatternModel(HourlyForecast forecast, RootBasicCityInfo cityInfo)
        {
            CityName = cityInfo.EnglishName;
            CountryName = cityInfo.Country.EnglishName;
            Temperature = forecast.Temperature.Value;
            IsDayLight = forecast.IsDaylight;
            HasPrecipitation = forecast.HasPrecipitation ? "Yes" : "No";
            PrecipitationProbability = forecast.PrecipitationProbability;
            ForecastMessage = forecast.IconPhrase;
            CityKey = cityInfo.Key;
            TimeOfNow = forecast.IsDaylight ? "day" : "night";
            WeatherIcon = forecast.WeatherIcon.ToString() + ".png";
        }


        /// <summary>
        /// The name of the current city.
        /// </summary>
        public string CityName { get; init; }

        /// <summary>
        /// The name of the current country.
        /// </summary>
        public string CountryName { get; init; }

        /// <summary>
        /// The temperature value.
        /// </summary>
        public double Temperature { get; init; }

        /// <summary>
        /// Indicates whether it is daylight or not
        /// </summary>
        public bool IsDayLight { get; init; }

        /// <summary>
        /// Indicates whether it has precipitation or not
        /// </summary>
        public string HasPrecipitation { get; init; }

        /// <summary>
        /// The probability of precipitation
        /// </summary>
        public int PrecipitationProbability { get; init; }

        /// <summary>
        /// The key of the current city.
        /// </summary>
        public string CityKey { get; init; }

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
