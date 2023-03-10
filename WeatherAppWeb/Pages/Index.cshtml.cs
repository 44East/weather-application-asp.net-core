using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Reflection.Metadata.Ecma335;

namespace WeatherAppWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private  WeatherAppInterfaceModel _weatherModel;
        public IEnumerable<string> Weather { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _weatherModel = new WeatherAppInterfaceModel();
            Weather = new List<string>();
        }

        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPost(string cityName)
        {
            if(cityName == null)
                return Page();
            Weather = await _weatherModel.GetWeather(cityName) ?? Weather.Append("The city was not found");
            return Page();

        }
        
        
    }
}