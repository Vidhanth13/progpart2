using AfriEnergy_ST10146835.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AfriEnergy_ST10146835.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Logger instance for logging

        // Constructor to inject the ILogger dependency
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action method for the Index page
        public IActionResult Index()
        {
            return View(); // Returns the default view for the Index action
        }

        // Action method for the Privacy page
        public IActionResult Privacy()
        {
            return View(); // Returns the Privacy view
        }

        // Action method for handling errors
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            // Returns the Error view with an ErrorViewModel object
        }
    }
}
