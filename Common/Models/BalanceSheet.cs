using System.Reflection.Metadata;

namespace Common.Models
{
    public class BalanceSheet
    {
        public List<LineItem> Assets { get; set; } = new List<LineItem>();
        public List<LineItem> Liabilities { get; set; } = new List<LineItem>();
        // I decided to use calculated properties for the remaining properties, discovered while bouncing ideas off of ChatGPT
        decimal TotalAssets => Assets.Sum(a => a.Amount);
        decimal TotalLiabilities => Liabilities.Sum(l => l.Amount);
        decimal Equity => TotalAssets - TotalLiabilities;
    }
}