namespace AfriEnergy_ST10146835.Models
{
    // Class for filtering and displaying products based on certain criteria
    public class FilterProducts
    {
        public string? ProductType { get; set; } // Property to hold the product type filter
        public DateTime? StartDate { get; set; } // Property to hold the start date filter
        public DateTime? EndDate { get; set; } // Property to hold the end date filter
        public List<Product> Products { get; set; } = new List<Product>(); // Collection of products that match the filters
    }
}
