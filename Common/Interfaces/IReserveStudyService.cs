using System.ComponentModel;
using Common.Models;

namespace Common.Interfaces
{
    /// <summary>
    /// Interface for the reserve study service. Contains methods for obtaining annual expenses, total expenses, and monthly HOA fees
    /// Also contains methods for database calls, utlizing an injected DAL
    /// </summary>
    public interface IReserveStudyService
    {
        List<decimal> GetAnnualExpenditures(List<RSComponent> components);
        decimal GetTotalExpenditures(List<decimal> totals);
        decimal GetMonthlyHOAFeePerUnit(decimal totalExpenditures, int numUnits);
        Task<List<RSComponent>> GetAllAsync();
        Task AddAsync(RSComponent component);
        Task DeleteAsync(RSComponent component);
        Task DeleteAllAsync();
    }
}