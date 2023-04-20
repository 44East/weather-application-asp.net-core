using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal class OperationDataLayer
    {
        private UserApiManager _userApiManager;
        private ReceiverWeather _receiverWeather;
        private SearcherCity _searcherCity;
        private List<UserApi> _userApis;
        private string _primaryApiKey;

        private bool _isApiDataInitialize;

        public OperationDataLayer(HttpClient httpClient)
        {
            _receiverWeather = new ReceiverWeather(httpClient);
            _searcherCity = new SearcherCity(httpClient);
            _userApiManager = new UserApiManager();
            _isApiDataInitialize = false;
            _primaryApiKey = string.Empty;
        }
        # region Api DAL
        private async Task InitializeApiDataAsync()
        {
            await _userApiManager.ReadUserApiFromLocalStorageAsync();
            _isApiDataInitialize = true;
            UpdateApiData();

        }
        private void UpdateApiData()
        {
            _userApis = _userApiManager.UserApiList;
            _primaryApiKey = _userApis?.FirstOrDefault()?.UserApiProperty ?? string.Empty;
        }
        private async Task EnsureInitializeApiDataAsync()
        {
            if (!_isApiDataInitialize)
                await InitializeApiDataAsync();
        }
        public async Task AddUserApiAsync(string api)
        {
            if (string.IsNullOrEmpty(api))
            { return; }

            await _userApiManager.WriteUserApiToLocalStorageAsync(api.Trim());
            UpdateApiData();

        }

        #endregion

        #region City DAL
        public async Task<List<RootBasicCityInfo>> GetListOfCitesOnRequestAsync(string cityName)
        {
            await EnsureInitializeApiDataAsync();
            return await _searcherCity.GetListOfCitesOnRequestAsync(cityName, _primaryApiKey);
        }
        #endregion

        #region Weather DAL
        public async Task<DailyRootWeather> GetWeatherForCityAsync(RootBasicCityInfo cityInfo)
        {
            await EnsureInitializeApiDataAsync();
            return await _receiverWeather.GetWeatherForFiveDaysAsync(cityInfo, _primaryApiKey);
        }

        public async Task<IEnumerable<HourlyForecast>> GetHalfDayWeatherAsync(RootBasicCityInfo cityInfo)
        {
            await EnsureInitializeApiDataAsync();
            return await _receiverWeather.GetHalfDayWeatherAsync(cityInfo, _primaryApiKey);
        }
        public async Task<IEnumerable<HourlyDetailedForecast>> GetDetailedHalfDayWeatherAsync(RootBasicCityInfo cityInfo)
        {
            await EnsureInitializeApiDataAsync();
            return await _receiverWeather.GetDetailedHalfDayWeatherAsync(cityInfo, _primaryApiKey);
        }
        #endregion
    }
}
