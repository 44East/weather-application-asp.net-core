using System.Text;
using System.Text.Json;


namespace WeatherApp
{
    public class ReceiverWeather
    {
        private SearcherCity searcherCity;
        private UserApiManager apiManager;
        private TextMessages textMessages;
        private TextWorker textWorker;
        public ReceiverWeather(TextMessages textMessages, TextWorker textWorker, SearcherCity searcherCity, UserApiManager apiManager)
        {
            this.textMessages = textMessages;            
            this.textWorker = textWorker;
            this.searcherCity = searcherCity;
            this.apiManager = apiManager;
        }        
        /// <summary>
        /// Метод запрашивает API ключ доступа к серверу и уникальный номер сохраненного города, если пара (ключ/номер) приняты сервером
        /// то метод выводит погоду на 5 дней по выбранному городу.
        /// Если список городов пуст или API ключ недоступен, выводится соответствующее сообщение по каждому событию и происходит выход из метода.
        /// </summary>
        public void GetWeatherDataFromServer()
        {            
            RootBasicCityInfo currentCity;
            string receivedWeatherForCurrentCity;
            StringBuilder fullUrlToRequest = new StringBuilder();
            RootWeather rootWeather;
            try 
            {
                currentCity = searcherCity.GetCurrentCity();
                string apiKey = apiManager.GetTheFirstKey();

                fullUrlToRequest.AppendFormat(textMessages.GetWeatherUrl, currentCity.Key, apiKey);

                receivedWeatherForCurrentCity = HttpWorker.GetStringFromServer(fullUrlToRequest.ToString());
                
                rootWeather = JsonSerializer.Deserialize<RootWeather>(receivedWeatherForCurrentCity);

                textWorker.ShowWeatherInCurrentCity(currentCity, rootWeather);
            }
            catch(ArgumentNullException ex)
            {
                textWorker.ShowTheText(ex.Message);
                return;
            }
            catch(NullReferenceException ex)
            {
                textWorker.ShowTheText(textMessages.ApiIsEmpty);
                textWorker.ShowTheText(ex.Message);
                return;
            }
            catch (AggregateException ex)
            {
                textWorker.ShowTheText(textMessages.NetworkOrHostIsNotAwailable);
                textWorker.ShowTheText(ex.Message);
                return;
            }
            catch(JsonException ex)
            {
                textWorker.ShowTheText(textMessages.ReceiveWeatherError);
                textWorker.ShowTheText(ex.Message);
            }
                             

        }
        public async Task<RootWeather> GetWeatherDataFromServerAsync(RootBasicCityInfo cityInfo)
        {
            string receivedWeatherForCurrentCity;
            StringBuilder fullUrlToRequest = new StringBuilder();
            try
            {
                string apiKey = apiManager.GetTheFirstKey();

                fullUrlToRequest.AppendFormat(textMessages.GetWeatherUrl, cityInfo.Key, apiKey);

                receivedWeatherForCurrentCity = await HttpWorker.GetStringFromServerAsync(fullUrlToRequest.ToString());

                return JsonSerializer.Deserialize<RootWeather>(receivedWeatherForCurrentCity);
            }
            catch (ArgumentNullException ex)
            {
                textWorker.ShowTheText(ex.Message);
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                textWorker.ShowTheText(textMessages.ApiIsEmpty);
                textWorker.ShowTheText(ex.Message);
                throw ex;
            }
            catch (AggregateException ex)
            {
                textWorker.ShowTheText(textMessages.NetworkOrHostIsNotAwailable);
                textWorker.ShowTheText(ex.Message);
                throw ex;
            }
            catch (JsonException ex)
            {
                textWorker.ShowTheText(textMessages.ReceiveWeatherError);
                textWorker.ShowTheText(ex.Message);
                throw ex;
            }
            
        }
        public async Task<List<string>> GetPreparedWeather(RootBasicCityInfo cityInfo)
        {
            var tempWeather = await GetWeatherDataFromServerAsync(cityInfo);
            var list = new List<string>();
            
            foreach (var item in tempWeather.DailyForecasts)
            {
                list.Add(string.Format(textMessages.PatternOfWeather, item.Temperature.Minimum.Value,
                                                                      item.Temperature.Maximum.Value, 
                                                                      item.Day.IconPhrase, 
                                                                      item.Night.IconPhrase, 
                                                                      cityInfo.LocalizedName));
                

            }
            return list;
        }
        
    }
}
