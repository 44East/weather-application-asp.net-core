

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
        /// Retrieves the half-day weather forecast for a city.
        /// </summary>
        /// <param name="cityInfo">The basic information for the city.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="HourlyForecast"/> objects representing the weather forecast.</returns>
        public async Task<IEnumerable<HourlyForecast>>GetHalfDayWeatherAsync(RootBasicCityInfo cityInfo)
        {
            return await _operationDAL.GetHalfDayWeatherAsync(cityInfo);
        }
        /// <summary>
        /// Retrieves the detailed half-day weather forecast for a city.
        /// </summary>
        /// <param name="cityInfo">The basic information for the city.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="HourlyDetailedForecast"/> objects representing the weather forecast.</returns>
        public async Task<IEnumerable<HourlyDetailedForecast>> GetDetailedHalfDayWeatherAsync(RootBasicCityInfo cityInfo)
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
