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
        private OperationDataLayer _operationDAL;

        public AppInterface()
        {
            _operationDAL = new OperationDataLayer();
        }
        public async Task AddUserApiAsync(string api)
        {
            await _operationDAL.AddUserApiAsync(api);

        }
        #region Weather
        public async Task<DailyRootWeather> GetWeatherForCityAsync(RootBasicCityInfo cityInfo)
        {
            return await _operationDAL.GetWeatherForCityAsync(cityInfo);
        }
        
        public async Task<IEnumerable<HourlyForecast>>GetHalfDayWeatherAsync(RootBasicCityInfo cityInfo)
        {
            return await _operationDAL.GetHalfDayWeatherAsync(cityInfo);
        }
        public async Task<IEnumerable<HourlyDetailedForecast>> GetDetailedHalfDayWeatherAsync(RootBasicCityInfo cityInfo)
        {
            return await _operationDAL.GetDetailedHalfDayWeatherAsync(cityInfo);
        }
        #endregion

        #region City
        public async Task<IEnumerable<RootBasicCityInfo>> FindCityAsync(string cityName)
        {
            return await _operationDAL.GetListOfCitesOnRequestAsync(cityName);
        }       

        #endregion
    }
}
