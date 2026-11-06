using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class LineItem
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(typeof(decimal), "0.01", "999999999999")]
        public decimal Amount { get; set; } = 0.0M;
    }
}