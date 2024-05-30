using Microsoft.AspNetCore.Mvc;

namespace AfriEnergy_ST10146835.Controllers
{
    public class EmployeeDashboardController : Controller
    {
        // Action method for displaying the employee dashboard
        public IActionResult Index()
        {
            return View(); // Returns the employee dashboard view
        }
    }
}
