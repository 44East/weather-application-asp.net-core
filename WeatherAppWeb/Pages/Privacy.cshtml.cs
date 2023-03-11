using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WeatherApp;

namespace WeatherAppWeb.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly WeatherAppInterfaceModel _interface;
        public string Title { get; private set; }
        
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
            _interface = new WeatherAppInterfaceModel();
             
        }

        public async Task OnGet()
        {
            Title =  await _interface.GetStringFromTextFileAsync("README.md");
        }
    }
}
