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
        /// Injecting the DAL for reserve study components, used for database calls
        /// </summary>
        private readonly IRSComponentsDAL rsComponentsDAL;

        public ReserveStudyService(IRSComponentsDAL rsComponentsDAL)
        {
            this.rsComponentsDAL = rsComponentsDAL;
        }
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
        /// <summary>
        /// Calls the GetAllAsync method from the injected DAL
        /// </summary>
        public Task<List<RSComponent>> GetAllAsync()
        {
            return rsComponentsDAL.GetAllAsync();
        }
        /// <summary>
        /// Calls the AddAsync method from the injected DAL
        /// </summary>
        /// <param name="component">Component to be added to the database</param>
        public Task AddAsync(RSComponent component)
        {
            return rsComponentsDAL.AddAsync(component);
        }
        /// <summary>
        /// Calls the DeleteAsync method from the injected DAL
        /// </summary>
        /// <param name="component">Component to be deleted from the database</param>
        /// <returns></returns>
        public Task DeleteAsync(RSComponent component)
        {
            return rsComponentsDAL.DeleteAsync(component);
        }
        /// <summary>
        /// Calls the DeleteAllAsync method from the injected DAL
        /// </summary>
        /// <returns></returns>
        public Task DeleteAllAsync()
        {
            return rsComponentsDAL.DeleteAllAsync();
        }
    }
}