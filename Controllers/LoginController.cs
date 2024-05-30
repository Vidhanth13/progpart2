using AfriEnergy_ST10146835.Models;
using Microsoft.AspNetCore.Mvc;

namespace AfriEnergy_ST10146835.Controllers
{
    public class LoginController : Controller
    {
        private readonly AfriFarmEnergyContext _context; // Database context for accessing user data

        // Constructor to inject the database context dependency
        public LoginController(AfriFarmEnergyContext context)
        {
            _context = context;
        }

        // GET action method for displaying the login form
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Returns the login view
        }

        // POST action method for processing login data
        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            // Check if the user exists and the password is correct
            if (user != null && PasswordClass.VerifyPassword(password, user.UserPassword))
            {
                if (user.UserRole == "Farmer")
                {
                    CurrentUser.currentUser = user.Username; // Set current user in session
                    return RedirectToAction("Index", "Products"); // Redirect to Products controller for farmers
                }
                else
                {
                    CurrentUser.currentUser = user.Username; // Set current user in session
                    return RedirectToAction("Index", "EmployeeDashboard"); // Redirect to EmployeeDashboard controller for employees
                }

            }
            return View(); // If login fails, return the login view again
        }
    }
}
