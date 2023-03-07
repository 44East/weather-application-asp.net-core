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
        public List<RootBasicCityInfo> GetSavedCity()
        {
            var currentCities = DataRepo.ListOfCitiesForMonitoringWeather;
            return currentCities;
        }
        public void AddUserApi(string api)
        {
            if (string.IsNullOrEmpty(api))
            { return; }

            ApiManager.WriteUserApiToLocalStorage(api.Trim());

        }
        public async Task<List<RootBasicCityInfo>> FindCityAsync(string cityName, string searchLanguage)
        {
            return await SearcherCity.GettingListOfCitesOnRequestAsync(cityName, searchLanguage);
        }
    }
}
