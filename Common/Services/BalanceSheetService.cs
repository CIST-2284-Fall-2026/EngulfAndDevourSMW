using Common.Interfaces;
using Common.Models;

namespace Common.Services
{
    public class BalanceSheetService : IBalanceSheetService
    {
        public decimal CalculateEquity(decimal totalAssets, decimal totalLiabilities)
        {
            return totalAssets - totalLiabilities;
        }

        public decimal CalculateTotalAssets(List<LineItem> assets)
        {
            return assets.Sum(a => a.Amount);
        }

        public decimal CalculateTotalLiabilities(List<LineItem> liabilities)
        {
            return liabilities.Sum(l => l.Amount);
        }
    }
}