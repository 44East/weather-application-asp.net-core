namespace WeatherAppWeb
{
    public class WeatherPatternModel
    {        
        public WeatherPatternModel(string cityName, string countryName, double minTemp, double maxTemp, string dayMessage, string nightMessage, string cityKey, string dayImageName, string nightImageName)
        {
            CityName = cityName;
            CountryName = countryName;
            MinTemp = minTemp;
            MaxTemp = maxTemp;
            DaytimeMessage = dayMessage;
            NighttimeMessage = nightMessage;
            CityKey = cityKey;
            DayImageName = dayImageName;
            NightImageName = nightImageName;
        }
        public string CityName { get; init; }
        public string CountryName { get; init; }
        public double MinTemp { get; init; }
        public double MaxTemp { get; init; }
        public string DaytimeMessage { get; init; }
        public string NighttimeMessage { get; init; }
        public string CityKey { get; init; }
        public string DayImageName { get; init; }
        public string NightImageName { get; init; }

    }
}
