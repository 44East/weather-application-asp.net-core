namespace WeatherAppWeb
{
    public class DailyWeatherPatternModel
    {
        public DailyWeatherPatternModel(string cityName, string countryName, double minTemp, double maxTemp, string dayMessage, string nightMessage, string cityKey, int dayWeatherIcon, int nightWeatherIcon)
        {
            CityName = cityName;
            CountryName = countryName;
            MinTemp = minTemp;
            MaxTemp = maxTemp;
            DaytimeMessage = dayMessage;
            NighttimeMessage = nightMessage;
            CityKey = cityKey;
            DayWeatherIcon = dayWeatherIcon.ToString() + ".png";
            NightWeatherIcon = nightWeatherIcon.ToString() + ".png";
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
