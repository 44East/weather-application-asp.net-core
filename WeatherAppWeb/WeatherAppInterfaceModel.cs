using WeatherApp;

namespace WeatherAppWeb
{
    public class WeatherAppInterfaceModel
    {
        public static readonly string FailureSearch = "The city was not found";
        private readonly AppInterface _interface;

        public WeatherAppInterfaceModel()
        {
            _interface = new AppInterface();
        }




        public async Task<IEnumerable<string>?> GetPreparedTextWeather(string cityName)
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
        public async Task<IDictionary<int, WeatherPatternModel>> GetWeather(string cityName)
        {
            IEnumerable<RootBasicCityInfo> cityList;
            IList<DailyForecast> rawWeather;
            IDictionary<int, WeatherPatternModel> weatherResult = new Dictionary<int, WeatherPatternModel>();
            RootBasicCityInfo cityFromTopSearch;
            try
            {
                cityList = await _interface.FindCityAsync(cityName, "en");
                if (cityList == null)
                    return weatherResult;
                cityFromTopSearch = cityList.First();
                rawWeather = (await _interface.GetWeatherForCityAsync(cityFromTopSearch)).DailyForecasts;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return weatherResult;
            }
            foreach (var item in rawWeather)
            {
                weatherResult.Add(rawWeather.IndexOf(item), new WeatherPatternModel(cityFromTopSearch.EnglishName,
                                                                                    cityFromTopSearch.Country.EnglishName,
                                                                                    item.Temperature.Minimum.Value,
                                                                                    item.Temperature.Maximum.Value,
                                                                                    item.Day.IconPhrase,
                                                                                    item.Night.IconPhrase,
                                                                                    cityFromTopSearch.Key,
                                                                                    string.Concat(item.Day.IconPhrase.Replace('/', 'h').Trim(), ".png"),//Cut symbol '/' from a text server result,
                                                                                    string.Concat(item.Night.IconPhrase.Replace('/', 'h').Trim(), ".png")));//and format the text message for dependence with a forecast image in a data source.
            }
            return weatherResult;
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
