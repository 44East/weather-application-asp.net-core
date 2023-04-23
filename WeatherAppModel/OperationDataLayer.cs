
namespace WeatherApp
{
    /// <summary>
    /// Represents a class that provides data access to the APIs, cities and weather.
    /// </summary>
    internal class OperationDataLayer
    {
        private UserApiManager _userApiManager;
        private ReceiverWeather _receiverWeather;
        private SearcherCity _searcherCity;
        private List<UserApi> _userApis;
        private string _primaryApiKey;

        private bool _isApiDataInitialize;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationDataLayer"/> class with the specified HTTP client.
        /// </summary>
        /// <param name="httpClient">The HTTP client to use for API requests.</param>
        public OperationDataLayer(HttpClient httpClient)
        {
            _receiverWeather = new ReceiverWeather(httpClient);
            _searcherCity = new SearcherCity(httpClient);
            _userApiManager = new UserApiManager();
            _isApiDataInitialize = false;
            _primaryApiKey = string.Empty;
        }
        #region Api DAL
        /// <summary>
        /// Initializes the API data asynchronously by reading the user API from local storage and updating the API data.
        /// </summary>
        /// <returns>A <see cref="Task"/>  representing the asynchronous operation.</returns>
        private async Task InitializeApiDataAsync()
        {
            await _userApiManager.ReadUserApiFromLocalStorageAsync();
            _isApiDataInitialize = true;
            UpdateApiData();

        }
        /// <summary>
        /// Updates the API data by getting the user API list and the primary API key.
        /// </summary>
        private void UpdateApiData()
        {
            _userApis = _userApiManager.UserApiList;
            _primaryApiKey = _userApis?.FirstOrDefault()?.UserApiProperty ?? string.Empty;
        }
        /// <summary>
        /// Ensures that the API data is initialized asynchronously.
        /// </summary>
        ///<returns>A <see cref="Task"/>  representing the asynchronous operation.</returns>
        private async Task EnsureInitializeApiDataAsync()
        {
            if (!_isApiDataInitialize)
                await InitializeApiDataAsync();
        }
        /// <summary>
        /// Adds the specified user API key asynchronously by writing it to storage and updating the API data.
        /// </summary>
        /// <param name="api">The user API key to add.</param>
        /// <returns>A <see cref="Task"/>  representing the asynchronous operation.</returns>
        public async Task AddUserApiAsync(string api)
        {
            if (string.IsNullOrEmpty(api))
            { return; }

            await _userApiManager.WriteUserApiToStorageAsync(api.Trim());
            UpdateApiData();

        }

        #endregion

        #region City DAL
        /// <summary>
        /// Gets a list of cities asynchronously based on the specified city name.
        /// </summary>
        /// <param name="cityName">The name of the city to search for.</param>
        /// <returns>A <see cref="List{T}"/>  of <see cref="RootBasicCityInfo"/> that match the specified city name.</returns>
        public async Task<List<RootBasicCityInfo>> GetListOfCitesOnRequestAsync(string cityName)
        {
            await EnsureInitializeApiDataAsync();
            return await _searcherCity.GetListOfCitesOnRequestAsync(cityName, _primaryApiKey);
        }
        #endregion

        #region Weather DAL
        /// <summary>
        /// Gets the weather for the specified city asynchronously.
        /// </summary>
        /// <param name="cityInfo">The city information to get the weather for.</param>
        /// <returns>The <see cref="DailyRootWeather"/> with the weather collection for the specified city.</returns>
        public async Task<DailyRootWeather> GetWeatherForCityAsync(RootBasicCityInfo cityInfo)
        {
            await EnsureInitializeApiDataAsync();
            return await _receiverWeather.GetWeatherForFiveDaysAsync(cityInfo, _primaryApiKey);
        }
        /// <summary>
        /// Retrieves the hourly forecast for the next 12 hours for a given city using the currently selected API key.
        /// </summary>
        /// <param name="cityInfo">The basic information of the city to retrieve the forecast for.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="HourlyForecast"/> objects representing the hourly forecast for the next 12 hours.</returns>
        public async Task<IEnumerable<HourlyForecast>> GetHalfDayWeatherAsync(RootBasicCityInfo cityInfo)
        {
            await EnsureInitializeApiDataAsync();
            return await _receiverWeather.GetHalfDayWeatherAsync(cityInfo, _primaryApiKey);
        }
        /// <summary>
        /// Retrieves the detailed hourly forecast for the next 12 hours for a given city using the currently selected API key.
        /// </summary>
        /// <param name="cityInfo">The basic information of the city to retrieve the detailed forecast for.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="HourlyDetailedForecast"/> objects representing the detailed hourly forecast for the next 12 hours.</returns>
        public async Task<IEnumerable<HourlyDetailedForecast>> GetDetailedHalfDayWeatherAsync(RootBasicCityInfo cityInfo)
        {
            await EnsureInitializeApiDataAsync();
            return await _receiverWeather.GetDetailedHalfDayWeatherAsync(cityInfo, _primaryApiKey);
        }
        #endregion
    }
}
