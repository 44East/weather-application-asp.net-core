namespace WeatherAppWeb
{
    public class HourlyWeatherPatternModel
    {
        public HourlyWeatherPatternModel(string cityKey, string cityName, string countryName, double temperature, bool isDayLight, bool hasPrecipitation, int precipitationProbability, string forecastMessage, string imageForecastName)
        {
            CityKey = cityKey;
            CityName = cityName;
            CountryName = countryName;
            Temperature = temperature;
            IsDayLight = isDayLight;
            HasPrecipitation = hasPrecipitation ? "Yes" : "No";
            PrecipitationProbability = precipitationProbability;
            ForecastMessage = forecastMessage;
            TimeOfNow = isDayLight ? "day" : "night";
            ImageForecastName = imageForecastName;
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
        public string ImageForecastName { get; set; }
    }
}
