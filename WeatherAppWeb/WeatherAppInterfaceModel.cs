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
        
        
        
        
        public async Task<IEnumerable<string>?> GetWeather(string cityName)
        {
            try
            {
                var cityList = await _interface.FindCityAsync(cityName, "en");
                if (cityList == null)
                    return null;

                return await _interface.GetPrepareWeatherAsync(cityList.First());
            }
            catch (Exception ex) 
            { 
                await Console.Out.WriteLineAsync(ex.Message);
                return null;
            }

        }
        public async Task<string> GetStringFromTextFileAsync(string fileName)
        {
            return await _interface.GetStringFromTextFileAsync(fileName);
        }
        public async Task AddApiKey(string apiKey)
        {
            await _interface.AddUserApiAsync(apiKey);
        }
    }
}
