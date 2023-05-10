using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherAppWeb.Patterns;

namespace WeatherAppWeb.Pages.HourlyForecast
{
    public class IndexModel : PageModel
    {
        private readonly WeatherAppInterfaceModel _model;
        public IDictionary<DateTime, HourlyDetailedWeatherPatternModel> HourlyForecast { get; set; }
        public IndexModel(WeatherAppInterfaceModel model)
        {
            _model = model;
        }
        public async Task OnGetAsync()
        {
            if(_model.CurrentCity != null) 
            {
                if (_model.HourlyForecast == null)
                {
                    HourlyForecast = await _model.GetHalfDaysDetailedWeatherAsync(_model.CurrentCity);
                }
                HourlyForecast = _model.HourlyForecast;
            }
        }
    }
}
