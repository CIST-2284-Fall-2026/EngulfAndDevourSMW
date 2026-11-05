using System.ComponentModel;
using Common.Models;

namespace Common.Interfaces
{
    public interface IReserveStudyService
    {
        List<decimal> GetAnnualExpenditures(List<RSComponent> components);
        decimal GetTotalExpenditures(List<decimal> totals);
        decimal GetMonthlyHOAFeePerUnit(decimal totalExpenditures, int numUnits);
    }
}