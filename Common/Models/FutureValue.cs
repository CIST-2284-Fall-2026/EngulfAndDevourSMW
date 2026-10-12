using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Common.Models
{
    public class FutureValue
    {
        private decimal principal = 0.01M;
        [Required]
        [Range(typeof(decimal), "0.01", "1000000000000", ErrorMessage = "Please enter a positive dollar value.")]
        public decimal Principal 
        { 
            get { return principal; } 
            set { principal = value; Calculate(); }  
        }
        private decimal interestRate = 0.01M;
        [Required]
        [Range(typeof(decimal), "0.01", "100.00", ErrorMessage = "Please enter a percentage value (0.01% - 100%)")]
        public decimal InterestRate 
        { 
            get { return interestRate; } 
            set { interestRate = value; Calculate(); } 
        }
        private int years = 1;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a whole number of years.")]
        public int Years 
        { 
            get { return years; } 
            set { years = value; Calculate(); } 
        }
        private int compoundsPerYear = 1;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a whole number of compounds per year.")]
        public int CompoundsPerYear 
        { 
            get { return compoundsPerYear; } 
            set { compoundsPerYear = value; Calculate(); } 
        }

        public decimal FutureVal { get; private set;}

        private void Calculate()
        {
            if (compoundsPerYear == 0)
            {
                return;
            }
            FutureVal = Principal * (decimal)Math.Pow((double)(1 + (InterestRate/100)/CompoundsPerYear), (CompoundsPerYear*Years));
        }
    }
}