using System.Runtime.CompilerServices;

namespace Common.Models
{
    public class FutureValue
    {
        public decimal Principal { get; set; } = 0.0M;
        public decimal InterestRate { get; set; } = 0.0M;
        public int Years { get; set; } = 0;
        public int CompoundsPerYear { get; set; } = 0;

        public decimal FutureVal { get; private set;}

        private void Calculate()
        {
            FutureVal = Principal * (decimal)Math.Pow((double)(1 + InterestRate/CompoundsPerYear), (CompoundsPerYear*Years));
        }
    }
}