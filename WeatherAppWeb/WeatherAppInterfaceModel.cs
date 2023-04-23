using Microsoft.Extensions.FileSystemGlobbing.Internal;
using WeatherApp;

namespace WeatherAppWeb
{
    /// <summary>
    /// This class represents the singleton instance of the Weather App Interface Model.
    /// It encapsulates the logic for interacting with the ModelAPI and exposes methods to retrieve weather data.
    /// </summary>
    public sealed class WeatherAppInterfaceModel
    {
        public static readonly string FailureSearch = "The city was not found";
        
        private static readonly HttpClient _httpCLient;
        
        private static readonly Lazy<WeatherAppInterfaceModel> lazy = new Lazy<WeatherAppInterfaceModel>(() => new WeatherAppInterfaceModel());
        
        private readonly ModelAPI _modelAPI;
        /// <summary>
        /// The static property that returns the singleton instance of the Weather App Interface Model.
        /// </summary>
        public static WeatherAppInterfaceModel Instance => lazy.Value;
        private WeatherAppInterfaceModel()
        {
            _modelAPI = new ModelAPI(_httpCLient);
        }
        static WeatherAppInterfaceModel()
        {
            _httpCLient = new HttpClient();
        }
        /// <summary>
        /// Gets the weather forecast for the next five days for the specified city.
        /// </summary>
        /// <param name="cityName">The name of the city for which to retrieve the weather forecast.</param>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> containing <see cref="DailyWeatherPatternModel"/>  for each day.</returns>
        public async Task<IDictionary<DateTime, DailyWeatherPatternModel>> GetFiveDaysWeatherAsync(string cityName)
        {
            // A temporary collection of cities. The first city in the collection has the highest probability of being a match.
            IEnumerable<RootBasicCityInfo> cityList;

            // This collection will be contains all weather data fields received from the server.
            IList<DailyForecast> rawWeather;

            // This dictionary will be contains the weather data for each day according to the weather pattern.
            IDictionary<DateTime, DailyWeatherPatternModel> weatherResult = new Dictionary<DateTime, DailyWeatherPatternModel>();

            // The current city instance from the temporary collection.
            RootBasicCityInfo cityFromTopSearch;
            try
            {
                // Search for the specified city.
                cityList = await _modelAPI.FindCityAsync(cityName);

                // Return an empty dictionary if the city is not found.
                if (cityList == null)
                    return weatherResult;

                // Get the first item from the city collection as it has the highest probability of being a match.
                cityFromTopSearch = cityList.First();

                // Get all the weather data for the specified city.
                rawWeather = (await _modelAPI.GetWeatherForCityAsync(cityFromTopSearch)).DailyForecasts;
            }
            catch (Exception ex)
            {
                // Log the error and return the empty dictionary.
                await Console.Out.WriteLineAsync(ex.Message);
                return weatherResult;
            }
            // Insert the relevant data in the dictionary from the raw weather collection.
            foreach (var item in rawWeather)
            {
                weatherResult.Add(item.Date, new DailyWeatherPatternModel(item, cityFromTopSearch));
            }
            return weatherResult;
        }
        /// <summary>
        /// Gets the weather forecast for the next 12 hours for the specified city.
        /// </summary>
        /// <param name="cityName">The name of the city for which to retrieve the weather forecast.</param>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> containing <see cref="HourlyWeatherPatternModel"/>  for each day.</returns>
        public async Task<IDictionary<DateTime, HourlyWeatherPatternModel>> GetHalfDaysWeatherAsync(string cityName)
        {
            // A temporary collection of cities. The first city in the collection has the highest probability of being a match.
            IEnumerable<RootBasicCityInfo> cityList;

            // This collection will be contains all weather data fields received from the server.
            IEnumerable<HourlyForecast> rawWeather;

            //This dictionary will contain weather data for 12 hours according to the weather pattern.
            IDictionary<DateTime, HourlyWeatherPatternModel> weatherResult = new Dictionary<DateTime, HourlyWeatherPatternModel>();


            // The current city instance from the temporary collection.
            RootBasicCityInfo cityFromTopSearch;
            try
            {
                // Search for the specified city.
                cityList = await _modelAPI.FindCityAsync(cityName);

                // Return an empty dictionary if the city is not found.
                if (cityList == null)
                    return weatherResult;

                // Get the first item from the city collection as it has the highest probability of being a match.
                cityFromTopSearch = cityList.First();

                // Get all the weather data for the specified city.
                rawWeather = await _modelAPI.GetHalfDayWeatherAsync(cityFromTopSearch);
            }
            catch (Exception ex)
            {
                // Log the error and return the empty dictionary.
                await Console.Out.WriteLineAsync(ex.Message);
                return weatherResult;
            }
            // Insert the relevant data in the dictionary from the raw weather collection.
            foreach (var item in rawWeather)
            {
                weatherResult.Add(item.DateTime, new HourlyWeatherPatternModel(item, cityFromTopSearch));
            }
            return weatherResult;
        }
        /// <summary>
        /// Adds an API key to the user's API keys file.
        /// </summary>
        /// <param name="apiKey">The API key to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddApiKey(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                return;
            await _modelAPI.AddUserApiAsync(apiKey);
        }
    }
}
