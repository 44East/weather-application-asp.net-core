

namespace WeatherApp
{
    /// <summary>
    /// This type contains text messages for showing them in a debug console and also it contains links to weather getters. 
    /// </summary>
    internal static class TextMessages
    {
        public static string ErorrsBySearch { get; } = "Failed to display the requested city.\n" +
                                                       "Possible reasons: \n" +
                                                       "* Incorrect search language\n" +
                                                       "* Incorrect city name\n" +
                                                       "Details below: \n";
        public static string ApiFileDoesntExist { get; } = "You have not yet added any access keys, or the current key is invalid." +
                                                            "\nUse the appropriate menu item to add a new key!";
        public static string ApiIsEmpty { get; } = "Your API key is not available, add it again, the file may have been deleted or moved\nWithout a key, you will not be able to search!";
        public static string NetworkOrHostIsNotAwailable { get; } = "It seems that there is no internet connection or the requested server is unavailable.";
        public static string SearchError { get; } = "The list of found cities is empty, because the search failed.";
        public static string ReceiveWeatherError { get; } = "Downloading weather from the server failed, please try again.";
        public static string ApiKeysFileName { get; } = "UserApiKeys.json";

        ///<summary>
        ///URL for searching a city on the server.
        ///Formating - {0} = apKey, {1} = cityName, 
        ///</summary>
        public static string SearchCityUrl { get; } = "http://dataservice.accuweather.com/locations/v1/cities/search?apikey={0}&q={1}&language=en"; //{0} = apKey, {1} = cityName
        ///<summary>
        ///URL for displaying weather for a specific city for 5 days.
        ///Formating - {0} = CurrentCity.Key, {1} = apiKey
        ///</summary>
        public static string GetFiveDaysWeatherUrl { get; } = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/{0}?apikey={1}&language=en&metric=true"; //{0} = CurrentCity.Key, {1} = apiKey
        ///<summary>
        ///URL for displaying detailed weather for a specific city for 5 days.
        ///Formating - {0} = CurrentCity.Key, {1} = apiKey
        ///</summary>
        public static string GetFiveDaysDetailedWeatherUrl { get; } = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/{0}?apikey={1}&language=en&details=true&metric=true"; //{0} = CurrentCity.Key, {1} = apiKey
        ///<summary>
        ///URL for displaying weather for a specific city for half a day.
        ///Formating - {0} = CurrentCity.Key, {1} = apiKey
        ///</summary>
        public static string GetHalfDayWeatherUrl { get; } = "http://dataservice.accuweather.com/forecasts/v1/hourly/12hour/{0}?apikey={1}&language=en&metric=true"; //{0} = CurrentCity.Key, {1} = apiKey
        ///<summary>
        ///URL for displaying detailed weather for a specific city for half a day.
        ///Formating - {0} = CurrentCity.Key, {1} = apiKey
        ///</summary>
        public static string GetDetailedHalfDayWeatherUrl { get; } = "http://dataservice.accuweather.com/forecasts/v1/hourly/12hour/{0}?apikey={1}&language=en&details=true&metric=true"; //{0} = CurrentCity.Key, {1} = apiKey
    }

}
