﻿using System.Text;
using System.Text.Json;


namespace WeatherApp
{
    /// <summary>
    /// The ReceiverWeather class is responsible for receiving and processing weather data using HttpClient.
    /// </summary>
    internal class ReceiverWeather
    {
        private readonly HttpClient _httpClient;
        /// <summary>
        /// Initializes a new instance of the ReceiverWeather class with the specified HttpClient instance.
        /// </summary>
        /// <param name="httpClient">An instance of the HttpClient class.</param>
        public ReceiverWeather(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <summary>
        /// This method requests an API key to access the server and the unique number of a saved city. If the pair (key/number) is accepted by the server,
        /// the method retrieves the weather for 5 days for the selected city.
        /// If the city list is empty or the API key is unavailable, a corresponding message is output for each event, and the method exits.
        /// </summary>
        /// <param name="cityInfo">The basic information for the city to retrieve the weather for</param>
        /// <param name="apiKey">The API key to use for the request</param>
        /// <returns>A <see cref="DailyRootWeather"/> object containing the weather data for the selected city</returns>
        public async Task<DailyRootWeather> GetWeatherForFiveDaysAsync(RootBasicCityInfo cityInfo, string apiKey)
        {
            string receivedWeatherForCurrentCity;
            try
            {

                receivedWeatherForCurrentCity = await _httpClient.GetStringAsync(string.Format(TextMessages.GetFiveDaysWeatherUrl, cityInfo.Key, apiKey));//HttpWorker.GetStringFromServerAsync(string.Format(textMessages.GetFiveDaysWeatherUrl, cityInfo.Key, apiKey));

                return JsonSerializer.Deserialize<DailyRootWeather>(receivedWeatherForCurrentCity);
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
            catch (NullReferenceException ex)
            {
                await Console.Out.WriteLineAsync(TextMessages.ApiIsEmpty);
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
            catch (AggregateException ex)
            {
                await Console.Out.WriteLineAsync(TextMessages.NetworkOrHostIsNotAwailable);
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
            catch (JsonException ex)
            {
                await Console.Out.WriteLineAsync(TextMessages.ReceiveWeatherError);
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
            
        }
        /// <summary>
        /// This method requests an API key to access the server and the unique number of a saved city. If the pair (key/number) is accepted by the server
        /// this method retrieves the hourly weather forecast for the selected city for the next 12 hours
        /// </summary>
        /// <param name="cityInfo">The basic information for the city to retrieve the weather for</param>
        /// <param name="apiKey">The API key to use for the request</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="HourlyForecast"/> objects containing the hourly weather data for the selected city for the next 12 hours</returns>
        public async Task<IEnumerable<HourlyForecast>> GetHalfDayWeatherAsync(RootBasicCityInfo cityInfo, string apiKey)
        {
            string receivedWeatherForCurrentCity;
            try
            {
                receivedWeatherForCurrentCity = await _httpClient.GetStringAsync(string.Format(TextMessages.GetHalfDayWeatherUrl, cityInfo.Key, apiKey));

                return JsonSerializer.Deserialize<IEnumerable<HourlyForecast>>(receivedWeatherForCurrentCity);
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
            catch (NullReferenceException ex)
            {
                await Console.Out.WriteLineAsync(TextMessages.ApiIsEmpty);
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
            catch (AggregateException ex)
            {
                await Console.Out.WriteLineAsync(TextMessages.NetworkOrHostIsNotAwailable);
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
            catch (JsonException ex)
            {
                await Console.Out.WriteLineAsync(TextMessages.ReceiveWeatherError);
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// This method requests an API key to access the server and the unique number of a saved city. If the pair (key/number) is accepted by the server
        /// this method retrieves the detailed hourly weather forecast for the selected city for the next 12 hours
        /// </summary>
        /// <param name="cityInfo">The basic information for the city to retrieve the weather for</param>
        /// <param name="apiKey">The API key to use for the request</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="HourlyDetailedForecast"/> objects containing the detailed hourly weather data for the selected city for the next 12 hours</returns>
        public async Task<IEnumerable<HourlyDetailedForecast>> GetDetailedHalfDayWeatherAsync(RootBasicCityInfo cityInfo, string apiKey)
        {
            string receivedWeatherForCurrentCity;
            try
            {
                receivedWeatherForCurrentCity = await _httpClient.GetStringAsync(string.Format(TextMessages.GetDetailedHalfDayWeatherUrl, cityInfo.Key, apiKey));

                return JsonSerializer.Deserialize<IEnumerable<HourlyDetailedForecast>>(receivedWeatherForCurrentCity);
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
            catch (NullReferenceException ex)
            {
                await Console.Out.WriteLineAsync(TextMessages.ApiIsEmpty);
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
            catch (AggregateException ex)
            {
                await Console.Out.WriteLineAsync(TextMessages.NetworkOrHostIsNotAwailable);
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
            catch (JsonException ex)
            {
                await Console.Out.WriteLineAsync(TextMessages.ReceiveWeatherError);
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }

    }

}
