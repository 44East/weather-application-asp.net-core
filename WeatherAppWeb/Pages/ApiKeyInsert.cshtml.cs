using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WeatherAppWeb.Pages
{
    public class ApiKeyInsertModel : PageModel
    {
        private readonly ILogger<ApiKeyInsertModel> _logger;
        private readonly WeatherAppInterfaceModel _api;
        public ApiKeyInsertModel(ILogger<ApiKeyInsertModel> logger, WeatherAppInterfaceModel weatherAppInterfaceModel)
        {
            _api = weatherAppInterfaceModel;
            _logger = logger;

        }
        public void OnGet()
        {
        }
        /// <summary>
        /// Called when the user insert a new key
        /// </summary>
        /// <param name="apiKey">The user's API key.</param>
        /// <returns>Index page.</returns>
        public async Task<IActionResult> OnPost(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                return Page();
            else
            {
                await _api.AddApiKey(apiKey);
                return RedirectToPage("Index");

            }
        }
    }
}
