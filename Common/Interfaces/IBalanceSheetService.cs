using Common.Models;

namespace Common.Interfaces
{
    /// <summary>
    /// Interface for the balance sheet service. Contains methods for calcualting total assets, liabilities, and equity
    /// Also contains methods for database calls, utilized with an injected DAL
    /// </summary>
    public interface IBalanceSheetService
    {
        decimal CalculateTotalAssets(List<LineItem> assets);
        decimal CalculateTotalLiabilities(List<LineItem> liabilities);
        decimal CalculateEquity(decimal totalAssets, decimal totalLiabilities);
        Task<List<LineItem>> GetAllAsync();
        Task AddAsync(LineItem item);
        Task DeleteAsync(LineItem item);
        Task DeleteAllAsync();
    }
}