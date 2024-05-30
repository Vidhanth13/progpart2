using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AfriEnergy_ST10146835.Models
{
    // Partial class representing a User entity
    public partial class User
    {
        // Unique identifier for the user
        public int UserId { get; set; }

        // Username of the user (required)
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = null!;

        // Password of the user (required, min length 6 characters)
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string UserPassword { get; set; } = null!;

        // Role of the user (required)
        public string UserRole { get; set; } = null!;

        // First name of the user (required)
        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }

        // Last name of the user (required)
        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }

        // Email address of the user (required, valid email format)
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        // Phone number of the user (optional, valid phone number format)
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string? Phone { get; set; }

        // Address of the user (optional)
        public string? Address { get; set; }

        // Date and time when the user was created
        public DateTime CreatedAt { get; set; }

        // Navigation property representing the associated Products
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
