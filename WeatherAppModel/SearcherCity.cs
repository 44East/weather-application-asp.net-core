using System.Text;
using System.Text.Json;

namespace WeatherApp
{
    public class SearcherCity
    {

        private UserApiManager apiManager;

        private TextMessages textMessages;
        public SearcherCity(TextMessages textMessages, UserApiManager apiManager)
        {
            this.textMessages = textMessages;
            this.apiManager = apiManager;
        }

        /// <summary>
        /// Метод принимает две строковые переменные, [1.название города кирилицей или латиницей] и [2.язык поискового запроса],
        /// экземпляр HttpWorker для обработки запроса к серверу.
        /// Возвращает массив данных из одного или нескольких городов, в зависимости от совпадений на сервере
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="searchLanguage"></param>
        public async Task<List<RootBasicCityInfo>> GetListOfCitesOnRequestAsync(string cityName)
        {
            StringBuilder fullUrlToRequest = new StringBuilder();
            try
            {
                string apiKey = apiManager.GetTheFirstKey();

                fullUrlToRequest.AppendFormat(textMessages.SearchCityUrl, apiKey, cityName);

                string prepareString = await HttpWorker.GetStringFromServerAsync(fullUrlToRequest.ToString());

                var rbci = JsonSerializer.Deserialize<List<RootBasicCityInfo>>(prepareString);
                if (rbci.Count == 0)
                    throw new JsonException(textMessages.SearchError);

                return rbci;

            }
            catch (NullReferenceException ex)
            {
                await Console.Out.WriteLineAsync(textMessages.ApiIsEmpty);
                await Console.Out.WriteLineAsync(ex.Message);
                throw ex;
            }
            catch (AggregateException ex)
            {
                await Console.Out.WriteLineAsync(textMessages.NetworkOrHostIsNotAwailable);
                await Console.Out.WriteLineAsync(ex.Message);               
                throw ex;
            }
            catch (JsonException ex)
            {
                await Console.Out.WriteLineAsync(textMessages.ErorrsBySearch + ex.Message);
                throw ex;
            }

        }
    }
}
