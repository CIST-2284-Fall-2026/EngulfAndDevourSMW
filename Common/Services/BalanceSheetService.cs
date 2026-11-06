using Common.Interfaces;
using Common.Models;

namespace Common.Services
{
    /// <summary>
    /// Balance sheet service, utilizing the IBalanceSheetService interface
    /// </summary>
    public class BalanceSheetService : IBalanceSheetService
    {
        /// <summary>
        /// Calculates the total equity of the balance sheet using total assets and total liabilities.
        /// </summary>
        /// <param name="totalAssets">Decimal value of total assets.</param>
        /// <param name="totalLiabilities">Decimal value of total liabilities.</param>
        /// <returns>Returns a decimal value representing the total equity.</returns>
        public decimal CalculateEquity(decimal totalAssets, decimal totalLiabilities)
        {
            return totalAssets - totalLiabilities;
        }
        /// <summary>
        /// Calculates the total assets of the balance sheet from a list of assets.
        /// </summary>
        /// <param name="assets">List of LineItems representing assets.</param>
        /// <returns>Returns a decimal value representing the total assets.</returns>
        public decimal CalculateTotalAssets(List<LineItem> assets)
        {
            return assets.Sum(a => a.Amount);
        }
        /// <summary>
        /// Calculates the total liabilites of the balance sheet from a list of liabilities.
        /// </summary>
        /// <param name="liabilities">List of LineItems representing liabilities.</param>
        /// <returns>Returns a decimal value representing the total liabilities.</returns>
        public decimal CalculateTotalLiabilities(List<LineItem> liabilities)
        {
            return liabilities.Sum(l => l.Amount);
        }
    }
}