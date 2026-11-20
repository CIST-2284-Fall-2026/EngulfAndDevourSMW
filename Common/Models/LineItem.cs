using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    /// <summary>
    /// This enum represents whether the line item is an asset or liability
    /// </summary>
    public enum BalanceSheetCategory
    {
        Asset,
        Liability
    }
    /// <summary>
    /// Class representing a line item on a balance sheet
    /// </summary>
    public class LineItem
    {
        /// <summary>
        /// Unique ID acts as a primary key in the database tables
        /// </summary>
        [Required]
        public Guid Id { get; set; }
        [Required]
        public BalanceSheetCategory Category { get; set; }
        /// <summary>
        /// A string representing the name of the line item. Must be between 5 and 100 characters long.
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// A decimal representing the dollar value of the line item. Must be a positive value.
        /// </summary>
        [Required]
        [Range(typeof(decimal), "0.01", "999999999999")] // This seems to be the accepted way of setting a decimal range
        public decimal Amount { get; set; } = 0.0M;
    }
}