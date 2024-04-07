using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApp.DTOs.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [StringLength(10, ErrorMessage = "Symbol cannot be more than 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [StringLength(20, ErrorMessage = "Company name cannot be more than 20 characters")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1, 1000000000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Industry name cannot be more than 10 characters")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(1, 5000000000)]
        public long MarketCap { get; set; }
    }
}
