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
        public TextWorker TextWorker { get; private set; }
        public DataRepo DataRepo { get; private set; }
        public SearcherCity SearcherCity { get; private set; }
        public UserApiManager ApiManager { get; private set; }

        public AppInterface()
        {
            TextMessages = new TextMessages();
            TextWorker = new TextWorker(TextMessages);
            TextWorker.ShowText += TextWorker.OutputText;

            DataRepo = new DataRepo(TextMessages, TextWorker);
            ApiManager = new UserApiManager(TextMessages, TextWorker);

            SearcherCity = new SearcherCity(TextMessages, TextWorker, ApiManager, DataRepo);

            ReceiverWeather = new ReceiverWeather(TextMessages, TextWorker, SearcherCity, ApiManager);

            InitializeUserFiles();

        }
        private void InitializeUserFiles()
        {
           ApiManager.ReadUserApiFromLocalStorage();
           DataRepo.ReadListOfCityMonitoring();
        }
        public async Task AddUserApiAsync(string api)
        {
            if (string.IsNullOrEmpty(api))
            { return; }

            await ApiManager.WriteUserApiToLocalStorageAsync(api.Trim());            

        }
        public async Task<string> GetStringFromTextFileAsync(string fileName)
        {
            return await DataRepo.GetStringFromTextFileAsync(fileName);
        }
        #region Weather
        public async Task<RootWeather> GetWeatherForCityAsync(RootBasicCityInfo cityInfo)
        {
            return await ReceiverWeather.GetWeatherDataFromServerAsync(cityInfo);
        }
        public async Task<List<string>> GetPrepareWeatherAsync(RootBasicCityInfo cityInfo)
        {
            return await ReceiverWeather.GetPreparedWeather(cityInfo);
        }
        #endregion

        #region City
        public async Task<IEnumerable<RootBasicCityInfo>> FindCityAsync(string cityName, string searchLanguage)
        {
            return await SearcherCity.GetListOfCitesOnRequestAsync(cityName, searchLanguage);
        }
        public async Task SaveCityAsync(RootBasicCityInfo cityInfo)
        {
            await DataRepo.AddCityInSavedListAsync(cityInfo);
        }
        public async Task RemoveCityAsync(RootBasicCityInfo cityInfo)
        {
            await DataRepo.RemoveCityFromSavedListAsync(cityInfo);
        }
        public IEnumerable<RootBasicCityInfo> GetSavedCity()
        {
            var currentCities = DataRepo.ListOfCitiesForMonitoringWeather;
            return currentCities;
        }
        public IEnumerable<string> GetPreparedSavedCity()
        {
            return DataRepo.GetPreparedListOfSavedCity();
        }
        public Task<IEnumerable<string>> GetPreparedCitiesListFromSearchAsync(string cityName, string searchLanguage)
        {
            return SearcherCity.GetPreparedListOfCityFromServerAsync(cityName, searchLanguage);
        }

        #endregion
    }
}
