using System.Text;
using System.Text.Json;

namespace WeatherApp
{
    internal class SearcherCity
    {

        private TextMessages textMessages;
        private readonly HttpClient _httpClient;
        public SearcherCity(HttpClient httpClient)
        {
            textMessages = new TextMessages();
            _httpClient = httpClient;
        }

        /// <summary>
        /// Метод принимает две строковые переменные, [1.название города кирилицей или латиницей] и [2.язык поискового запроса],
        /// экземпляр HttpWorker для обработки запроса к серверу.
        /// Возвращает массив данных из одного или нескольких городов, в зависимости от совпадений на сервере
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="searchLanguage"></param>
        public async Task<List<RootBasicCityInfo>> GetListOfCitesOnRequestAsync(string cityName, string apiKey)        {
            
            try
            { 

                string prepareString = await _httpClient.GetStringAsync(string.Format(textMessages.SearchCityUrl, apiKey, cityName));

                var rbci = JsonSerializer.Deserialize<List<RootBasicCityInfo>>(prepareString);
                if (rbci.Count == 0)
                    throw new JsonException(textMessages.SearchError);

                return rbci;

            }
            catch (NullReferenceException ex)
            {
                await Console.Out.WriteLineAsync(textMessages.ApiIsEmpty);
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
            catch (AggregateException ex)
            {
                await Console.Out.WriteLineAsync(textMessages.NetworkOrHostIsNotAwailable);
                await Console.Out.WriteLineAsync(ex.Message);               
                throw;
            }
            catch (JsonException ex)
            {
                await Console.Out.WriteLineAsync(textMessages.ErorrsBySearch + ex.Message);
                throw;
            }

        }
    }
}
