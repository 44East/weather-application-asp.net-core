using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace WeatherAppWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly WeatherAppInterfaceModel _weatherModel;
        public IDictionary<DateTime, DailyWeatherPatternModel> Weather { get; set; }
        public IDictionary<DateTime, HourlyWeatherPatternModel> HourlyWeather { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _weatherModel = new WeatherAppInterfaceModel();
            Weather = new Dictionary<DateTime, DailyWeatherPatternModel>();
            HourlyWeather = new Dictionary<DateTime, HourlyWeatherPatternModel>();
        }

        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPost(string cityName, string typeForecast)
        {
            if(cityName == null)
                return Page();
            if(typeForecast.Equals("5Day"))
                Weather = await _weatherModel.GetFiveDaysWeatherAsync(cityName);
            if(typeForecast.Equals("12Hour"))
                HourlyWeather = await _weatherModel.GetHalfDaysWeatherAsync(cityName);
            return Page();

        }
        
        
    }
}