using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WeatherAppWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WeatherAppInterfaceModel _model;
        public IndexModel(WeatherAppInterfaceModel model)
        {
            _model = model;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string forecastType, string cityName)
        {
            if(!string.IsNullOrEmpty(cityName))
            {
                _model.CurrentCity = await _model.FindTheCityAsync(cityName);
                if (_model.CurrentCity != null)
                {
                    switch(forecastType)
                    {
                        case "Day":
                            return RedirectToPage("/DailyForecast/Index");
                        case "Hour":
                            return RedirectToPage("/HourlyForecast/Index");
                        default:
                              return Page();
                    }
                }
                else
                {
                    return Page();
                }
            }
            return Page();
        }
    }
}
