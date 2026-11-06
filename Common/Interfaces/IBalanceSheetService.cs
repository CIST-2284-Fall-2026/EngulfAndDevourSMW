using Common.Models;

namespace Common.Interfaces
{
    /// <summary>
    /// Interface for the balance sheet service. Contains methods for calcualting total assets, liabilities, and equity
    /// </summary>
    public interface IBalanceSheetService
    {
        decimal CalculateTotalAssets(List<LineItem> assets);
        decimal CalculateTotalLiabilities(List<LineItem> liabilities);
        decimal CalculateEquity(decimal totalAssets, decimal totalLiabilities);
    }
}