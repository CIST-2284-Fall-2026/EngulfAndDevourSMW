using System.Reflection.Metadata;

namespace Common.Models
{
    /// <summary>
    /// Balance Sheet model class
    /// </summary>
    public class BalanceSheet
    {
        /// <summary>
        /// Stores Assets as LineItem objects
        /// </summary>
        public List<LineItem> Assets { get; set; } = new List<LineItem>();
        /// <summary>
        /// Stores Liabilities as LineItem objects
        /// </summary>
        public List<LineItem> Liabilities { get; set; } = new List<LineItem>();
    }
}