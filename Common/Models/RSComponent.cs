using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    /// <summary>
    /// Class representing a component of a reserve study
    /// </summary>
    public class RSComponent
    {
        /// <summary>
        /// String representing the name of the component, must be 5-100 characters long
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 5)] 
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Integer representing the useful life of the component in years. Must be a positive value.
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int UsefulLife { get; set; } = 1;
        /// <summary>
        /// Decimal representing the replacement cost of the component in dollars. Must be positive.
        /// </summary>
        [Required]
        [Range(typeof(decimal), "0.01", "999999999999")] // This appears to be the accepted way to use range with a decimal.
        public decimal ReplacementCost { get; set; } = 0.0M;
    }
}
