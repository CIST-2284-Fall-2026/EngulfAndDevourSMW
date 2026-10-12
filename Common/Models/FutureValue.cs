using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Common.Models
{
    /// <summary>
    /// This is a model class to calculate future value given Principal, Annual Interest Rate, Number of Years, and how often it compounds per year. 
    /// </summary>
    public class FutureValue
    {
        private decimal principal = 0.01M;
        [Required]
        [Range(typeof(decimal), "0.01", "1000000000000", ErrorMessage = "Please enter a positive dollar value.")]
        
        /// <summary>
        /// Represents the principal investment in dollars. Validation prevents zero and negative values, and limits input to $1 Trillion.
        /// </summary>
        public decimal Principal 
        { 
            get { return principal; } 
            set { principal = value; Calculate(); }  
        }
        private decimal interestRate = 0.01M;
        [Required]
        [Range(typeof(decimal), "0.01", "100.00", ErrorMessage = "Please enter a percentage value (0.01% - 100%)")]

        /// <summary>
        /// Represents the annual interest rate as a percentage value. This will be divided by 100 when actual calculations are done. Validation prevents zero, negative, and values over 100.
        /// </summary>
        public decimal InterestRate 
        { 
            get { return interestRate; } 
            set { interestRate = value; Calculate(); } 
        }
        private int years = 1;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a whole number of years.")]

        /// <summary>
        /// Represents the number of years for the investment. Validation prevents zero and negative values.
        /// </summary>
        public int Years 
        { 
            get { return years; } 
            set { years = value; Calculate(); } 
        }
        private int compoundsPerYear = 1;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a whole number of compounds per year.")]

        /// <summary>
        /// Represents how often the compounding interest occurs per year. Validation prevents zero and negative values.
        /// </summary>
        public int CompoundsPerYear 
        { 
            get { return compoundsPerYear; } 
            set { compoundsPerYear = value; Calculate(); } 
        }

        /// <summary>
        /// Represents the future value of the investment. Calculated any time another variable is updated.
        /// </summary>
        public decimal FutureVal { get; private set;}

        // Calculates future value based on current variables. If attempting to divide by zero, simply returns zero. If attempting to calculate negative future value, also returns zero. Formula is Principle*(1+Rate/CompoundsPerYear)^(CompoundsPerYear*Years)
        private void Calculate()
        {
            if (compoundsPerYear == 0)
            {
                FutureVal = 0;
                return;
            }
            if (principal < 0 || interestRate < 0 || years < 0 || compoundsPerYear < 0)
            {
                FutureVal = 0;
                return;
            }
            FutureVal = Principal * (decimal)Math.Pow((double)(1 + (InterestRate/100)/CompoundsPerYear), (CompoundsPerYear*Years));
        }
    }
}