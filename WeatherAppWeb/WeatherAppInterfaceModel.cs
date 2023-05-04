using Microsoft.Extensions.FileSystemGlobbing.Internal;
using WeatherApp;
using WeatherAppWeb.Patterns;

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
        /// A Key value pairs for the hourly weather
        /// </summary>
        public IDictionary<DateTime, HourlyDetailedWeatherPatternModel> HourlyForecast { get; set; }
        /// <summary>
        /// A Key value pairs for the daily weather
        /// </summary>
        public IDictionary<DateTime, DailyWeatherPatternModel> DailyForecast { get; set; }
        /// <summary>
        /// The current instance of the seraching cities
        /// </summary>
        public RootBasicCityInfo CurrentCity { get; set; }
        /// <summary>
        /// Find the city by the name
        /// </summary>
        /// <param name="cityName">The name of the city that need to find </param>
        /// <returns>An instance of the <see cref="RootBasicCityInfo"/></returns>
        public async Task<RootBasicCityInfo> FindTheCityAsync(string cityName)
        {
            try
            {
                // Search for the specified city.
                return (await _modelAPI.FindCityAsync(cityName))?.First();
            }
            catch (Exception ex)
            {
                // Log the error
                await Console.Out.WriteLineAsync(ex.Message);
                //In release it must return null
                throw;
            }
        }
        /// <summary>
        /// Gets the weather forecast for the next five days for the specified city.
        /// </summary>
        /// <param name="cityName">The name of the city for which to retrieve the weather forecast.</param>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> containing <see cref="DailyWeatherPatternModel"/>  for each day.</returns>
        public async Task<IDictionary<DateTime, DailyWeatherPatternModel>> GetFiveDaysWeatherAsync(RootBasicCityInfo currentCity)
        {
          

            // This collection will be contains all weather data fields received from the server.
            IList<DailyForecast> rawWeather;

            // This dictionary will be contains the weather data for each day according to the weather pattern.
            IDictionary<DateTime, DailyWeatherPatternModel> weatherResult = new Dictionary<DateTime, DailyWeatherPatternModel>();
            try
            {
                // Get all the weather data for the specified city.
                rawWeather = (await _modelAPI.GetWeatherForCityAsync(currentCity)).DailyForecasts;
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
                weatherResult.Add(item.Date, new DailyWeatherPatternModel(item, currentCity));
            }
            return weatherResult;
        }
        
        /// <summary>
        /// Gets the detailed weather forecast for the next 12 hours for the specified city.
        /// </summary>
        /// <param name="cityName">The name of the city for which to retrieve the weather forecast.</param>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> containing <see cref="HourlyDetailedWeatherPatternModel"/>  for each day.</returns>
        public async Task<IDictionary<DateTime, HourlyDetailedWeatherPatternModel>> GetHalfDaysDetailedWeatherAsync(RootBasicCityInfo currentCity)
        {

            // This collection will be contains all weather data fields received from the server.
            IEnumerable<HourlyDetailedForecast> rawWeather;

            //This dictionary will contain weather data for 12 hours according to the weather pattern.
            IDictionary<DateTime, HourlyDetailedWeatherPatternModel> weatherResult = new Dictionary<DateTime, HourlyDetailedWeatherPatternModel>();
            try
            {
                // Get all the weather data for the specified city.
                rawWeather = await _modelAPI.GetHalfDaysDetailedWeatherAsync(currentCity);
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
                weatherResult.Add(item.DateTime, new HourlyDetailedWeatherPatternModel(item, currentCity));
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
