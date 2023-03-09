using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WeatherAppWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private  WeatherAppInterfaceModel _weatherModel;
        public IDictionary<string, string> Cities { get; set; }
        public IEnumerable<string> Weather { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _weatherModel = new WeatherAppInterfaceModel();
            Cities = _weatherModel.GetSavedCity();
            Weather = new List<string>();
        }

        public void OnGet()
        {
            
        }
        public IActionResult OnPost(string cityName)
        {
            var cityKey = Cities.Where(k => k.Value == cityName).Select(k => k.Key).FirstOrDefault();
            if (!string.IsNullOrEmpty(cityKey))
            {
                Weather = _weatherModel.GetWeather(cityKey);
                return Page();
            }
            return NotFound();
        }
    }
}