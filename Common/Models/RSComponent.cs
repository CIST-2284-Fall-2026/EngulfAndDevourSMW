using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class RSComponent
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0, int.MaxValue)]
        public int UsefulLife { get; set; } = 0;
        [Required]
        [Range(typeof(decimal), "0.01", "999999999999")]
        public decimal ReplacementCost { get; set; } = 0.0M;
    }
}
