using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WeatherAppWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private  WeatherAppInterfaceModel _weatherModel;
        public IEnumerable<string> Cities { get; set; } 
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _weatherModel = new WeatherAppInterfaceModel();
            Cities = _weatherModel.GetSavedCity();
        }

        public void OnGet()
        {
            
            
        }
    }
}