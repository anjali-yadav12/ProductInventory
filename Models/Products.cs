using System.ComponentModel.DataAnnotations;

namespace Product_Inventory.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty; // ✅ required & default non-null

        [MaxLength(500)]
        public string? Description { get; set; } // ✅ optional

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; } = string.Empty; // ✅ required & default non-null
         

    }
}
