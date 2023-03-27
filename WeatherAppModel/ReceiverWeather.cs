using System.Text;
using System.Text.Json;


namespace WeatherApp
{
    public class ReceiverWeather
    {
        private UserApiManager apiManager;
        private TextMessages textMessages;
        public ReceiverWeather(TextMessages textMessages, UserApiManager apiManager)
        {
            this.textMessages = textMessages; 
            this.apiManager = apiManager;
        }        
        /// <summary>
        /// Метод запрашивает API ключ доступа к серверу и уникальный номер сохраненного города, если пара (ключ/номер) приняты сервером
        /// то метод выводит погоду на 5 дней по выбранному городу.
        /// Если список городов пуст или API ключ недоступен, выводится соответствующее сообщение по каждому событию и происходит выход из метода.
        /// </summary>

        public async Task<DailyRootWeather> GetWeatherForFiveDaysAsync(RootBasicCityInfo cityInfo)
        {
            string receivedWeatherForCurrentCity;
            StringBuilder fullUrlToRequest = new StringBuilder();
            try
            {
                string apiKey = apiManager.GetTheFirstKey();

                fullUrlToRequest.AppendFormat(textMessages.GetFiveDaysWeatherUrl, cityInfo.Key, apiKey);

                receivedWeatherForCurrentCity = await HttpWorker.GetStringFromServerAsync(fullUrlToRequest.ToString());

                return JsonSerializer.Deserialize<DailyRootWeather>(receivedWeatherForCurrentCity);
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw ex;
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
                await Console.Out.WriteLineAsync(textMessages.ReceiveWeatherError);
                await Console.Out.WriteLineAsync(ex.Message);
                throw ex;
            }
            
        }
        public async Task<IEnumerable<HourlyForecast>> GetHalfDayWeatherAsync(RootBasicCityInfo cityInfo)
        {
            string receivedWeatherForCurrentCity;
            StringBuilder fullUrlToRequest = new StringBuilder();
            try
            {
                string apiKey = apiManager.GetTheFirstKey();

                fullUrlToRequest.AppendFormat(textMessages.GetHalfDayWeatherUrl, cityInfo.Key, apiKey);

                receivedWeatherForCurrentCity = await HttpWorker.GetStringFromServerAsync(fullUrlToRequest.ToString());

                return JsonSerializer.Deserialize<IEnumerable<HourlyForecast>>(receivedWeatherForCurrentCity);
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw ex;
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
                await Console.Out.WriteLineAsync(textMessages.ReceiveWeatherError);
                await Console.Out.WriteLineAsync(ex.Message);
                throw ex;
            }
        }
        
    }

}
