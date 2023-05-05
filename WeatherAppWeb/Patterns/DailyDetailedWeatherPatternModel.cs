using WeatherApp;
using WeatherApp.Data.WeatherDataTemplate.DailyDetaiedTemplate;
namespace WeatherAppWeb.Patterns

{
    public class DailyDetailedWeatherPatternModel
    {
        public DailyDetailedWeatherPatternModel(DetailedDailyForecast forecast, RootBasicCityInfo cityInfo)
        {
            CityName = cityInfo.EnglishName;
            CountryName = cityInfo.Country.EnglishName;
            MinTemp = forecast.Temperature.Minimum.Value;
            MaxTemp = forecast.Temperature.Maximum.Value;
            DaytimeMessage = forecast.Day.IconPhrase;
            NighttimeMessage = forecast.Night.IconPhrase;
            CityKey = cityInfo.Key;
            DayWeatherIcon = forecast.Day.Icon.ToString() + ".png";
            NightWeatherIcon = forecast.Night.Icon.ToString() + ".png";
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
        /// The minimal temperature value for a day.
        /// </summary>
        public double MinTemp { get; init; }
        /// <summary>
        /// The maximum temperature value for a day.
        /// </summary>
        public double MaxTemp { get; init; }
        /// <summary>
        /// The daytime forecast message with the weather review.
        /// </summary>
        public string DaytimeMessage { get; init; }
        /// <summary>
        /// The nighttime forecast message with the weather review.
        /// </summary>
        public string NighttimeMessage { get; init; }
        /// <summary>
        /// The key of the current city.
        /// </summary>
        public string CityKey { get; init; }
        /// <summary>
        /// Contains the weather icon file name.
        /// </summary>
        public string DayWeatherIcon { get; set; }
        /// <summary>
        /// Contains the weather icon file name.
        /// </summary>
        public string NightWeatherIcon { get; set; }

    }

}
