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
        public IEnumerable<string> PreparedWeather { get; set; }
        public IDictionary<int, WeatherPatternModel> Weather { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _weatherModel = new WeatherAppInterfaceModel();
            PreparedWeather = new List<string>();
            Weather = new Dictionary<int, WeatherPatternModel>();
        }

        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPost(string cityName)
        {
            if(cityName == null)
                return Page();
            Weather = await _weatherModel.GetWeather(cityName);            
            return Page();

        }
        
        
    }
}