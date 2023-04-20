using WeatherApp;

namespace WeatherAppWeb
{
    public class HourlyWeatherPatternModel
    {
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
        

        public string CityName { get; init; }
        public string CountryName { get; init; }
        public double Temperature { get; init; }
        public bool  IsDayLight { get; init; }
        public string HasPrecipitation { get; init; }
        public int PrecipitationProbability { get; init; }
        public string CityKey { get; init; }
        public string ForecastMessage { get; init; }
        public string TimeOfNow { get; set; }
        public string WeatherIcon { get; set; }
    }
}
