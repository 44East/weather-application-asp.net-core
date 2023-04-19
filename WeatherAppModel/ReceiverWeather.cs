using System.Text;
using System.Text.Json;


namespace WeatherApp
{
    internal class ReceiverWeather
    {
        private TextMessages textMessages;
        public ReceiverWeather()
        {
            textMessages = new TextMessages(); 
        }        
        /// <summary>
        /// Метод запрашивает API ключ доступа к серверу и уникальный номер сохраненного города, если пара (ключ/номер) приняты сервером
        /// то метод выводит погоду на 5 дней по выбранному городу.
        /// Если список городов пуст или API ключ недоступен, выводится соответствующее сообщение по каждому событию и происходит выход из метода.
        /// </summary>

        public async Task<DailyRootWeather> GetWeatherForFiveDaysAsync(RootBasicCityInfo cityInfo, string apiKey)
        {
            string receivedWeatherForCurrentCity;
            try
            {

                receivedWeatherForCurrentCity = await HttpWorker.GetStringFromServerAsync(string.Format(textMessages.GetFiveDaysWeatherUrl, cityInfo.Key, apiKey));

                return JsonSerializer.Deserialize<DailyRootWeather>(receivedWeatherForCurrentCity);
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
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
                await Console.Out.WriteLineAsync(textMessages.ReceiveWeatherError);
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
            
        }
        public async Task<IEnumerable<HourlyForecast>> GetHalfDayWeatherAsync(RootBasicCityInfo cityInfo, string apiKey)
        {
            string receivedWeatherForCurrentCity;
            try
            {
                receivedWeatherForCurrentCity = await HttpWorker.GetStringFromServerAsync(string.Format(textMessages.GetFiveDaysWeatherUrl, cityInfo.Key, apiKey));

                return JsonSerializer.Deserialize<IEnumerable<HourlyForecast>>(receivedWeatherForCurrentCity);
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
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
                await Console.Out.WriteLineAsync(textMessages.ReceiveWeatherError);
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<HourlyDetailedForecast>> GetDetailedHalfDayWeatherAsync(RootBasicCityInfo cityInfo, string apiKey)
        {
            string receivedWeatherForCurrentCity;
            try
            {
                receivedWeatherForCurrentCity = await HttpWorker.GetStringFromServerAsync(string.Format(textMessages.GetFiveDaysWeatherUrl, cityInfo.Key, apiKey));

                return JsonSerializer.Deserialize<IEnumerable<HourlyDetailedForecast>>(receivedWeatherForCurrentCity);
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
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
                await Console.Out.WriteLineAsync(textMessages.ReceiveWeatherError);
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }

    }

}
