using WeatherApp;

namespace WeatherAppWeb
{
    public class DailyWeatherPatternModel
    {
        public DailyWeatherPatternModel(DailyForecast forecast, RootBasicCityInfo cityInfo)
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
        public string CityName { get; init; }
        public string CountryName { get; init; }
        public double MinTemp { get; init; }
        public double MaxTemp { get; init; }
        public string DaytimeMessage { get; init; }
        public string NighttimeMessage { get; init; }
        public string CityKey { get; init; }
        public string DayWeatherIcon { get; set; }
        public string NightWeatherIcon { get; set; }

    }
}
