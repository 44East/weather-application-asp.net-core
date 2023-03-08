using WeatherApp;

namespace WeatherAppWeb
{
    public class WeatherAppInterfaceModel
    {
        private readonly AppInterface _interface;

        public WeatherAppInterfaceModel()
        {
            _interface = new AppInterface();
        }
        public IEnumerable<string> GetSavedCity()
        {
            var tempList = _interface.GetSavedCity();
            var result = new List<string>();
            foreach (var city in tempList) 
            {
                result.Add(city.EnglishName + " " + city.Country.EnglishName + " " + city.Region.EnglishName);
            }
            return result;
        }
    }
}
