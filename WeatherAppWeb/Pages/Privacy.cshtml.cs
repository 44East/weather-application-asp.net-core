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
        public string Title { get; private set; }
        private FileWorker<string> _fileWorker = new FileWorker<string>();
        
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
             
        }

        public async Task OnGet()
        {
            Title =  await _fileWorker.ReadTextFromLocalStorageAsync("README.md");
        }
    }
}
