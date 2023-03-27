using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class AppInterface
    {
        public ReceiverWeather ReceiverWeather { get; private set; }
        public TextMessages TextMessages { get; private set; }
        public SearcherCity SearcherCity { get; private set; }
        public UserApiManager ApiManager { get; private set; }

        public AppInterface()
        {
            TextMessages = new TextMessages();

            ApiManager = new UserApiManager(TextMessages);
            ApiManager.ReadUserApiFromLocalStorage();
            SearcherCity = new SearcherCity(TextMessages, ApiManager);

            ReceiverWeather = new ReceiverWeather(TextMessages, ApiManager);

        }
        public async Task AddUserApiAsync(string api)
        {
            if (string.IsNullOrEmpty(api))
            { return; }

            await ApiManager.WriteUserApiToLocalStorageAsync(api.Trim());            

        }
        #region Weather
        public async Task<DailyRootWeather> GetWeatherForCityAsync(RootBasicCityInfo cityInfo)
        {
            return await ReceiverWeather.GetWeatherForFiveDaysAsync(cityInfo);
        }
        
        public async Task<IEnumerable<HourlyForecast>>GetHalfDayWeatherAsync(RootBasicCityInfo cityInfo)
        {
            return await ReceiverWeather.GetHalfDayWeatherAsync(cityInfo);
        }
        #endregion

        #region City
        public async Task<IEnumerable<RootBasicCityInfo>> FindCityAsync(string cityName)
        {
            return await SearcherCity.GetListOfCitesOnRequestAsync(cityName);
        }
        

        #endregion
    }
}
