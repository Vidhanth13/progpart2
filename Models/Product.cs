using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AfriEnergy_ST10146835.Models
{
    // Partial class representing a Product entity
    public partial class Product
    {
        // Unique identifier for the product
        public int ProductId { get; set; }

        // UserId associated with the product (required)
        [Required(ErrorMessage = "UserId is required.")]
        public int? UserId { get; set; }

        // Name of the product (required, max length 50 characters)
        [Required(ErrorMessage = "ProductName is required.")]
        [StringLength(50, ErrorMessage = "ProductName must not exceed 50 characters.")]
        public string ProductName { get; set; } = null!;

        // Category of the product (optional, max length 50 characters)
        [StringLength(50, ErrorMessage = "Category must not exceed 50 characters.")]
        public string? Category { get; set; }

        // Production date of the product (optional, date format)
        [DataType(DataType.Date, ErrorMessage = "Invalid ProductionDate format.")]
        public DateTime? ProductionDate { get; set; }

        // Navigation property representing the associated User entity
        public virtual User? User { get; set; }
    }
}
