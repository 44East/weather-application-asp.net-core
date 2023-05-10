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
            //Reset the saved information about the current city and the all forecasts
            _model.CurrentCity = default;
            _model.HourlyForecast = default;
            _model.DailyForecast = default;

        }
        public async Task<IActionResult> OnPostAsync(string forecastType, string cityName)
        {
            //Checking the user input
            if(!string.IsNullOrEmpty(cityName))
            {
                //If the search finds the city it checks the user choice (Daily or Hourly forecast) and redirects to the relevant page
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
                    //If search doesn't find the city, refresh the page
                    return Page();
                }
            }
            return Page();
        }
    }
}
