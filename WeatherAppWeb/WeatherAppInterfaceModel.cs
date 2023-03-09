using WeatherApp;

namespace WeatherAppWeb
{
    public class WeatherAppInterfaceModel
    {
        private readonly AppInterface _interface;
        private readonly IEnumerable<RootBasicCityInfo> _basicCityInfos;

        public WeatherAppInterfaceModel()
        {
            _interface = new AppInterface();
            _basicCityInfos = _interface.GetSavedCity();
        }
        public IDictionary<string, string> GetSavedCity()
        {
            var tempList = _interface.GetSavedCity();
            var dictResult = new Dictionary<string, string>();
            foreach (var city in tempList)
            {
                if (dictResult.ContainsKey(city.Key))
                    continue;
                dictResult.Add(city.Key, city.EnglishName);
            }
            return dictResult;
        }
        public IEnumerable<string> GetWeather(string cityKey)
        {   
            RootBasicCityInfo currentCity = (from city 
                                             in _basicCityInfos 
                                             where city.Key == cityKey 
                                             select city).FirstOrDefault();
            return _interface.GetPrepareWeatherAsync(currentCity).Result;        

        }
    }
}
