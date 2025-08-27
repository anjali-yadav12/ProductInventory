using System.ComponentModel.DataAnnotations;

namespace Product_Inventory.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty; // ✅ default to avoid null warnings

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; } // ✅ optional

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [MaxLength(50, ErrorMessage = "Category cannot exceed 50 characters")]
        public string Category { get; set; } = string.Empty; // ✅ default
    }
}
