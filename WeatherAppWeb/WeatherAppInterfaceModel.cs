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

        public async Task<IDictionary<DateTime, DailyWeatherPatternModel>> GetFiveDaysWeatherAsync(string cityName)
        {

            IEnumerable<RootBasicCityInfo> cityList;//The temp cities collection, the first city from collection has more accident

            IList<DailyForecast> rawWeather;//This collection contains the all weather data fields which received from server

            //Thic dictionary contains the Key = It's a day of weather, and the Value = a special pattern of the weather with a basic info.
            IDictionary<DateTime, DailyWeatherPatternModel> weatherResult = new Dictionary<DateTime, DailyWeatherPatternModel>();

            RootBasicCityInfo cityFromTopSearch;//The current city instance from the temp collection
            try
            {
                cityList = await _interface.FindCityAsync(cityName);//Search of the city

                if (cityList == null)//return the empty dictionary if the city didn't find
                    return weatherResult;

                cityFromTopSearch = cityList.First();//Get the first item of the city instance from the collection because it has more accident

                rawWeather = (await _interface.GetWeatherForCityAsync(cityFromTopSearch)).DailyForecasts;//Get the all weather data by day's from the property collection in a model of the APP
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return weatherResult;
            }
            foreach (var item in rawWeather)//Insert the relevant data in the dict. from the raw weather collection
            {
                weatherResult.Add(item.Date, new DailyWeatherPatternModel(item, cityFromTopSearch));
            }
            return weatherResult;
        }
        public async Task<IDictionary<DateTime, HourlyWeatherPatternModel>> GetHalfDaysWeatherAsync(string cityName)
        {

            IEnumerable<RootBasicCityInfo> cityList;//The temp cities collection, the first city from collection has more accident

            IEnumerable<HourlyForecast> rawWeather;//This collection contains the all weather data fields which received from server

            //Thic dictionary contains the Key = It's a day of weather, and the Value = a special pattern of the weather with a basic info.
            IDictionary<DateTime, HourlyWeatherPatternModel> weatherResult = new Dictionary<DateTime, HourlyWeatherPatternModel>();

            RootBasicCityInfo cityFromTopSearch;//The current city instance from the temp collection
            try
            {
                cityList = await _interface.FindCityAsync(cityName);//Search of the city

                if (cityList == null)//return the empty dictionary if the city didn't find
                    return weatherResult;

                cityFromTopSearch = cityList.First();//Get the first item of the city instance from the collection because it has more accident

                rawWeather = await _interface.GetHalfDayWeatherAsync(cityFromTopSearch);//Get the all weather data by day's from the property collection in a model of the APP
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return weatherResult;
            }
            foreach (var item in rawWeather)//Insert the relevant data in the dict. from the raw weather collection
            {
                weatherResult.Add(item.DateTime, new HourlyWeatherPatternModel(item, cityFromTopSearch));
            }
            return weatherResult;
        }

        public async Task AddApiKey(string apiKey)
        {
            await _interface.AddUserApiAsync(apiKey);
        }
    }
}
