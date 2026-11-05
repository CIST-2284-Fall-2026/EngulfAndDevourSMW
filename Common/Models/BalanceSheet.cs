using System.Reflection.Metadata;

namespace Common.Models
{
    public class BalanceSheet
    {
        public List<LineItem> Assets { get; set; } = new List<LineItem>();
        public List<LineItem> Liabilities { get; set; } = new List<LineItem>();
    }
}