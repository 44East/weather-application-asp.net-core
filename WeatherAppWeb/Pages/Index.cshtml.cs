using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using WeatherAppWeb.Patterns;

namespace WeatherAppWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly WeatherAppInterfaceModel _weatherModel;
        public IDictionary<DateTime, DailyWeatherPatternModel> Weather { get; set; }
        public IDictionary<DateTime, HourlyWeatherPatternModel> HourlyWeather { get; set; }
        public IndexModel(ILogger<IndexModel> logger, WeatherAppInterfaceModel weatherAppInterfaceModel)
        {
            _logger = logger;
            _weatherModel = weatherAppInterfaceModel;
            Weather = new Dictionary<DateTime, DailyWeatherPatternModel>();
            HourlyWeather = new Dictionary<DateTime, HourlyWeatherPatternModel>();
        }

        public void OnGet()
        {
            
        }
        /// <summary>
        /// Handles the HTTP POST request to retrieve weather data for a given city and forecast type.
        /// If cityName is null, returns the page without performing any action.
        /// If typeForecast is "5Day", retrieves the five-day weather forecast for the given city using the injected _weatherModel object.
        /// If typeForecast is "12Hour", retrieves the half-day weather forecast for the given city using the injected _weatherModel object.
        /// </summary>
        /// <param name="cityName">The name of the city for which weather data is requested.</param>
        /// <param name="typeForecast">The type of forecast to retrieve ("5Day" or "12Hour").</param>
        /// <returns>The page with the retrieved weather data.</returns>
        public async Task<IActionResult> OnPost(string cityName, string typeForecast)
        {
            if(cityName == null)
                return Page();
            if (typeForecast.Equals("5Day"))
            {
                Weather = await _weatherModel.GetFiveDaysWeatherAsync(cityName);
                typeForecast = string.Empty;
            }
            if (typeForecast.Equals("12Hour"))
            {
                HourlyWeather = await _weatherModel.GetHalfDaysWeatherAsync(cityName);
                typeForecast = string.Empty;
            }
            return Page();

        }
        
        
    }
}