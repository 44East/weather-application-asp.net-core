using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WeatherAppWeb.Pages
{
    public class ApiKeyInsertModel : PageModel
    {
        private readonly ILogger<ApiKeyInsertModel> _logger;
        private readonly WeatherAppInterfaceModel _interface;
        public ApiKeyInsertModel(ILogger<ApiKeyInsertModel> logger, WeatherAppInterfaceModel weatherAppInterfaceModel)
        {
            _interface = weatherAppInterfaceModel;
            _logger = logger;

        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                return Page();
            else
            {
                await _interface.AddApiKey(apiKey);
                return RedirectToPage("Index");

            }
        }
    }
}
