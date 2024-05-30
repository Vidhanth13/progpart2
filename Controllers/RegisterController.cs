using AfriEnergy_ST10146835.Models;
using Microsoft.AspNetCore.Mvc;

namespace AfriEnergy_ST10146835.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AfriFarmEnergyContext _context; // Database context for accessing user data

        // Constructor to inject the database context dependency
        public RegisterController(AfriFarmEnergyContext context)
        {
            _context = context;
        }

        // GET action method for displaying the registration form
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Returns the registration view
        }

        // POST action method for processing registration data
        [HttpPost]
        public IActionResult Index(User user, string Password)
        {
            if (ModelState.IsValid && user.UserPassword == Password)
            {
                if (_context.Users.Any(u => u.Username == user.Username || u.Email == user.Email))
                {
                    ModelState.AddModelError("", "Username or Email already exists.");
                    return View(user); // If username or email already exists, return the registration view with error message
                }
                // Encrypt the password before saving to the database
                user.UserPassword = PasswordClass.SetPassword(Password);
                user.CreatedAt = DateTime.Now; // Set the creation date/time

                // Save the user to the database
                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Index", "Login"); // Redirect to login page after successful registration

            }

            return RedirectToAction("Index", "Home"); // If model state is not valid, redirect to home page
        }
    }
}
