using Common.Models;

namespace Common.Interfaces
{
    public interface IBalanceSheetService
    {
        decimal CalculateTotalAssets(List<LineItem> assets);
        decimal CalculateTotalLiabilities(List<LineItem> liabilities);
        decimal CalculateEquity(decimal totalAssets, decimal totalLiabilities);
    }
}