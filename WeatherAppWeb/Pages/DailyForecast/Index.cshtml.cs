using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherAppWeb.Patterns;

namespace WeatherAppWeb.Pages.DailyForecast
{
    public class IndexModel : PageModel
    {

        private readonly WeatherAppInterfaceModel _model;
        public IDictionary<DateTime, DailyDetailedWeatherPatternModel> DailyWeather { get; set; }
        public IndexModel(ILogger<IndexModel> logger, WeatherAppInterfaceModel weatherAppInterfaceModel)
        {
            _model = weatherAppInterfaceModel;
        }

        public async Task OnGetAsync()
        {
            if (_model.CurrentCity != null)
            {
                _model.DailyForecast = await _model.GetFiveDaysDetailedWeatherAsync(_model.CurrentCity);
                DailyWeather = _model.DailyForecast;
            }
        }


    }
}