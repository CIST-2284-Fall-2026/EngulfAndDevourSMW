using Common.Models;
using Common.Interfaces;

namespace Common.Services
{
    public class ReserveStudyService : IReserveStudyService
    {
        public List<decimal> GetAnnualExpenditures(List<RSComponent> components)
        {
            List<decimal> totals = new();
            for (int year = 1; year <= ReserveStudy.StudyHorizon; year++)
            {
                decimal total = 0.0M;
                foreach (RSComponent comp in components)
                {
                    if (year % comp.UsefulLife == 0)
                    {
                        total += comp.ReplacementCost;
                    }
                }
                totals.Add(total);
            }
            return totals;
        }

        public decimal GetMonthlyHOAFeePerUnit(decimal totalExpenditures, int numUnits)
        {
            if (numUnits <= 0)
            {
                throw new ArgumentException("Please make sure that number of units is greater than zero.");
            }
            return totalExpenditures / (ReserveStudy.StudyHorizon * 12) / numUnits;
        }

        public decimal GetTotalExpenditures(List<decimal> totals)
        {
            return totals.Sum();
        }
    }
}