using System.ComponentModel;
using Common.Models;

namespace Common.Interfaces
{
    /// <summary>
    /// Interface for the reserve study service. Contains methods for obtaining annual expenses, total expenses, and monthly HOA fees
    /// </summary>
    public interface IReserveStudyService
    {
        List<decimal> GetAnnualExpenditures(List<RSComponent> components);
        decimal GetTotalExpenditures(List<decimal> totals);
        decimal GetMonthlyHOAFeePerUnit(decimal totalExpenditures, int numUnits);
    }
}