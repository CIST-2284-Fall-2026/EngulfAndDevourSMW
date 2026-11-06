using Common.Models;
using Common.Interfaces;

namespace Common.Services
{
    /// <summary>
    /// Reserve study service that implements IReserveStudyService
    /// </summary>
    public class ReserveStudyService : IReserveStudyService
    {
        /// <summary>
        /// Calculates annual expenditures for the length of the reserve study.
        /// </summary>
        /// <param name="components">A list of RSComponents representing the components of the study.</param>
        /// <returns>Returns a list of decimal values. Each value represents the total cost for a year.</returns>
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
        /// <summary>
        /// Calculates the recommended monthly HOA fee per unit.
        /// </summary>
        /// <param name="totalExpenditures">A decimal value representing the total expenditures for the study.</param>
        /// <param name="numUnits">An integer representing the total nubmer of units the HOA oversees.</param>
        /// <returns>Returns a decimal representing the recommended monthly HOA fee per unit.</returns>
        /// <exception cref="ArgumentException"></exception>
        public decimal GetMonthlyHOAFeePerUnit(decimal totalExpenditures, int numUnits)
        {
            if (numUnits <= 0)
            {
                throw new ArgumentException("Please make sure that number of units is greater than zero.");
            }
            return totalExpenditures / (ReserveStudy.StudyHorizon * 12) / numUnits;
        }
        /// <summary>
        /// Calculates total expenditures for the study.
        /// </summary>
        /// <param name="totals">A list of decimal values representing annual expenditures.</param>
        /// <returns>Returns a decimal value representing the total expenditures of the study.</returns>
        public decimal GetTotalExpenditures(List<decimal> totals)
        {
            return totals.Sum();
        }
    }
}