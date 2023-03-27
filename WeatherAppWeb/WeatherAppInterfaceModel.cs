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
                weatherResult.Add(item.Date, new DailyWeatherPatternModel(cityFromTopSearch.EnglishName,
                                                                          cityFromTopSearch.Country.EnglishName,
                                                                          item.Temperature.Minimum.Value,
                                                                          item.Temperature.Maximum.Value,
                                                                          item.Day.IconPhrase,
                                                                          item.Night.IconPhrase,
                                                                          cityFromTopSearch.Key,
                                                                          //Cut symbol '/' from a text server result,
                                                                          //and format the text message for dependence with a forecast image in a data source.
                                                                          string.Concat(item.Day.IconPhrase.Replace('/', 'h').Trim(), ".png"),
                                                                          string.Concat(item.Night.IconPhrase.Replace('/', 'h').Trim(), ".png")));
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
                weatherResult.Add(item.DateTime, new HourlyWeatherPatternModel(cityFromTopSearch.Key,
                                                                               cityFromTopSearch.EnglishName,
                                                                               cityFromTopSearch.Country.EnglishName,
                                                                               item.Temperature.Temperature,
                                                                               item.IsDaylight,
                                                                               item.HasPrecipitation,
                                                                               item.PrecipitationProbability,
                                                                               item.IconPhrase,
                                                                               //Cut symbol '/' from a text server result,
                                                                               //and format the text message for dependence with a forecast image in a data source.
                                                                               string.Concat(item.IconPhrase.Replace('/', 'h').Trim(), ".png")));
                                                                         
            }
            return weatherResult;
        }

        public async Task AddApiKey(string apiKey)
        {
            await _interface.AddUserApiAsync(apiKey);
        }
    }
}
