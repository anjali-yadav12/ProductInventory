using System.ComponentModel.DataAnnotations;

namespace Product_Inventory.DTOs
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [MaxLength(50)]
        public string Category { get; set; } = string.Empty;
    }
}
