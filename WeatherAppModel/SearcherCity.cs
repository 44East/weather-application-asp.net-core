using System.Text.Json;

namespace WeatherApp
{
    /// <summary>
    /// This class represents a searcher for a city and contains a method for retrieving a list of cities based on the search parameters.
    /// </summary>
    internal class SearcherCity
    {

        private TextMessages textMessages;
        private readonly HttpClient _httpClient;
        /// <summary>
        /// Initializes a new instance of the <see cref="SearcherCity"/> class with the specified <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="httpClient">An instance of <see cref="HttpClient"/> to use for making requests.</param>
        public SearcherCity(HttpClient httpClient)
        {
            textMessages = new TextMessages();
            _httpClient = httpClient;
        }

        /// <summary>
        /// Retrieves a list of basic information about cities based on the search parameters.
        /// </summary>
        /// <param name="cityName">The name of the city to search for in Cyrillic or Latin characters.</param>
        /// <param name="apiKey">The API key to use for making the request.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="RootBasicCityInfo"/> objects representing the cities that match the search parameters.</returns>
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
