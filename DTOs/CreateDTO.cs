using System.ComponentModel.DataAnnotations;

namespace SupermarketAPI.DTOs
{
    public class CreateDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public int SellingPrice { get; set; }
    }
}
