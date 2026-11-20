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
        /// Injecting the line items DAL here for database operations
        /// </summary>
        private readonly ILineItemsDAL lineItemsDAL;
        public BalanceSheetService(ILineItemsDAL lineItemsDAL)
        {
            this.lineItemsDAL = lineItemsDAL;
        }
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
        /// <summary>
        /// Calls the GetAllAsync method on the injected DAL
        /// </summary>
        public Task<List<LineItem>> GetAllAsync()
        {
            return lineItemsDAL.GetAllAsync();
        }
        /// <summary>
        /// Calls the AddAsync method on the injected DAL
        /// </summary>
        /// <param name="item">Item to be added to the database</param>
        public Task AddAsync(LineItem item)
        {
            return lineItemsDAL.AddAsync(item);
        }
        /// <summary>
        /// Calls the DeleteAsync method on the injected DAL
        /// </summary>
        /// <param name="item">Item to be deleted from the database</param>
        public Task DeleteAsync(LineItem item)
        {
            return lineItemsDAL.DeleteAsync(item);
        }
        /// <summary>
        /// Calls the DeleteAllAsync method on the injected DAL
        /// </summary>
        public Task DeleteAllAsync()
        {
            return lineItemsDAL.DeleteAllAsync();
        }
    }
}