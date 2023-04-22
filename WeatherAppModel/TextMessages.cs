

namespace WeatherApp
{
    /// <summary>
    /// This type contains text messages for showing them in a debug console and also it contains links to weather getters. 
    /// </summary>
    internal record TextMessages
    (
        string ErorrsBySearch = "Не получилось отобразить запрашиваемый город.\n" +
                                "Возможные причины: \n" +
                                "* Неправильно указан язык поиска\n" +
                                "* Не правильно указано название города\n" +
                                "Подробнее ниже: \n",
        string ApiFileDoesntExist = "Вы еще не добавили ни одного ключа доступа, либо текущий ключ недействителен." +
                                    "\nВоспользуйтесь соответствующим пунктом меню и добавьте новый ключ!",
        string CityFileDoesntExist = "Похоже файл с сохраненными городами удален, пермещен или еще не был создан.",
        string CityFileFailure = "Файл с городами пуст или нечитаем, добавьте новые города в список",
        string CityListWritingFailure = "Ошибка записи в файл, список городов поврежден",
        string IntParseError = "Ввод должен содержать только числовой набор символов!\n",
        string CityNoExist = "Такого номера нет. Попробуйте еще раз.",              
        string IncorrectInput = "Некорректный ввод!\n",
        string CityListIsEmpty = "Список городов пуст, добавьте город в список!",
        string ApiIsEmpty = "Ваш API ключ недоступен, добавьте его вновь, возможно файл был удален или перемещен\nБез ключа вы не сможете осуществлять поиск!",
        string NetworkOrHostIsNotAwailable = "Похоже отсутствует соединение с интернетом или запрашиваемый сервер недоступен.",
        string SearchError = "Список найденных городов пуст, т.к. поиск завершился неудачей.",
        string ReceiveWeatherError = "Выгрузка погоды с сервера завершилась неудачей, повторите попытку.",
        string ApiKeysFileName = "UserApiKeys.json"
        )
    {
        ///<summary>
        ///Ссылка для поиска города на сервере.
        ///{0} = apKey, {1} = cityName, 
        ///</summary>
        public string SearchCityUrl { get; } = "http://dataservice.accuweather.com/locations/v1/cities/search?apikey={0}&q={1}&language=en"; //{0} = apKey, {1} = cityName
        ///<summary>
        ///Ссылка для вывода погоды по конкретному городу на 5 дней.
        ///{0} = CurrentCity.Key, {1} = apiKey
        ///</summary>
        public string GetFiveDaysWeatherUrl { get; } = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/{0}?apikey={1}&language=en&metric=true"; //{0} = CurrentCity.Key, {1} = apiKey
        public string GetHalfDayWeatherUrl { get; } = "http://dataservice.accuweather.com/forecasts/v1/hourly/12hour/{0}?apikey={1}&language=en&metric=true"; //{0} = CurrentCity.Key, {1} = apiKey
        public string GetDetailedHalfDayWeatherUrl { get; } = "http://dataservice.accuweather.com/forecasts/v1/hourly/12hour/{0}?apikey={1}&language=en&details=true&metric=true"; //{0} = CurrentCity.Key, {1} = apiKey
    }

}
