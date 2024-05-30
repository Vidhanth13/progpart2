using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AfriEnergy_ST10146835.Models;

namespace AfriEnergy_ST10146835.Controllers
{
    public class ViewListingController : Controller
    {
        private readonly AfriFarmEnergyContext _context; // Database context for accessing product data

        // Constructor to inject the database context dependency
        public ViewListingController(AfriFarmEnergyContext context)
        {
            _context = context;
        }

        // Action method for displaying product listings with optional filters
        public async Task<IActionResult> Index(string? productType, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Products.Include(p => p.User).AsQueryable(); // Include user information in the query

            if (!string.IsNullOrEmpty(productType))
            {
                query = query.Where(p => p.Category == productType); // Filter by product type
            }

            if (startDate.HasValue)
            {
                query = query.Where(p => p.ProductionDate >= startDate); // Filter by start date
            }

            if (endDate.HasValue)
            {
                query = query.Where(p => p.ProductionDate <= endDate); // Filter by end date
            }

            // Construct the model to pass to the view
            var model = new FilterProducts
            {
                ProductType = productType,
                StartDate = startDate,
                EndDate = endDate,
                Products = await query.ToListAsync() // Execute the query and convert results to list asynchronously
            };

            return View(model); // Return the view with the model data
        }
    }
}
