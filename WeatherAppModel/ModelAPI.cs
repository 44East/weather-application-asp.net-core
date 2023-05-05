using WeatherApp.Data.WeatherDataTemplate.HourlyDetailedTemplate;
using WeatherApp.Data.WeatherDataTemplate.DailyDetaiedTemplate;

namespace WeatherApp
{
    /// <summary>
    /// Represents an API class that provides access to weather library.
    /// </summary>
    public class ModelAPI
    {
        
        private OperationDataLayer _operationDAL;
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelAPI"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client to use for API requests.</param>
        public ModelAPI(HttpClient httpClient)
        {
            _operationDAL = new OperationDataLayer(httpClient);
        }
        /// <summary>
        /// Adds a new user API to the list of APIs.
        /// </summary>
        /// <param name="api">The API to add.</param>
        /// <returns>A <see cref="Task"/>  representing the asynchronous operation.</returns>
        public async Task AddUserApiAsync(string api)
        {
            await _operationDAL.AddUserApiAsync(api);

        }
        #region Weather
        /// <summary>
        /// Retrieves the daily weather forecast for a city.
        /// </summary>
        /// <param name="cityInfo">The basic information for the city.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="DailyRootWeather"/> objects representing the weather forecast.</returns>
        public async Task<DailyRootWeather> GetWeatherForCityAsync(RootBasicCityInfo cityInfo)
        {
            return await _operationDAL.GetWeatherForCityAsync(cityInfo);
        }
        /// <summary>
        /// Gets the detailed weather for next five days for the specified city asynchronously. 
        /// </summary>
        /// <param name="cityInfo">The city information to get the weather for.</param>
        /// <returns>The <see cref="RootDailyDetailedWeather"/> with the weather collection for the specified city.</returns>
        public async Task<RootDailyDetailedWeather> GetDetailedWeatherForFiveDaysAsync(RootBasicCityInfo cityInfo)
        {
            return await _operationDAL.GetDetailedWeatherForFiveDaysAsync(cityInfo);
        }
        /// <summary>
        /// Retrieves the detailed half-day weather forecast for a city.
        /// </summary>
        /// <param name="cityInfo">The basic information for the city.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="HourlyDetailedForecast"/> objects representing the weather forecast.</returns>
        public async Task<IEnumerable<HourlyDetailedForecast>> GetHalfDaysDetailedWeatherAsync(RootBasicCityInfo cityInfo)
        {
            return await _operationDAL.GetDetailedHalfDayWeatherAsync(cityInfo);
        }
        #endregion

        #region City
        /// <summary>
        /// Searches for a city by name.
        /// </summary>
        /// <param name="cityName">The name of the city to search for.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="RootBasicCityInfo"/> objects representing the cities that match the search query.</returns>
        public async Task<IEnumerable<RootBasicCityInfo>> FindCityAsync(string cityName)
        {
            return await _operationDAL.GetListOfCitesOnRequestAsync(cityName);
        }       

        #endregion
    }
}
