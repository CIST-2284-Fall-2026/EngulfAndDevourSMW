using Common.Models;
using Common.Services;

namespace Tests.Common.Services
{
    [TestClass]
    public sealed class ReserveStudyTests
    {
        [TestMethod]
        public void AnnualExpendituresListComparison()
        {
            ReserveStudyService testService = new ReserveStudyService();
            ReserveStudy testStudy = new ReserveStudy();
            RSComponent comp1 = new RSComponent();
            comp1.Name = "Comp1";
            comp1.UsefulLife = 1;
            comp1.ReplacementCost = 100m;
            RSComponent comp2 = new RSComponent();
            comp2.Name = "Comp2";
            comp2.UsefulLife = 30;
            comp2.ReplacementCost = 1000m;
            RSComponent comp3 = new RSComponent();
            comp3.Name = "Comp3";
            comp3.UsefulLife = 15;
            comp3.ReplacementCost = 500m;
            testStudy.Components.Add(comp1);
            testStudy.Components.Add(comp2);
            testStudy.Components.Add(comp3);
            List<decimal> result = testService.GetAnnualExpenditures(testStudy.Components);
            List<decimal> expected = new();
            for (int i = 1; i <= 30; i++)
            {
                if (i == 15)
                {
                    expected.Add(600m);
                }
                else if (i == 30)
                {
                    expected.Add(1600m);
                }
                else
                {
                    expected.Add(100m);
                }
            }
            CollectionAssert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TotalExpendituresExpected5000()
        {
            ReserveStudyService testService = new ReserveStudyService();
            ReserveStudy testStudy = new ReserveStudy();
            RSComponent comp1 = new RSComponent();
            comp1.Name = "Comp1";
            comp1.UsefulLife = 1;
            comp1.ReplacementCost = 100m;
            RSComponent comp2 = new RSComponent();
            comp2.Name = "Comp2";
            comp2.UsefulLife = 30;
            comp2.ReplacementCost = 1000m;
            RSComponent comp3 = new RSComponent();
            comp3.Name = "Comp3";
            comp3.UsefulLife = 15;
            comp3.ReplacementCost = 500m;
            testStudy.Components.Add(comp1);
            testStudy.Components.Add(comp2);
            testStudy.Components.Add(comp3);
            decimal expected = 5000m;
            decimal result = testService.GetTotalExpenditures(testService.GetAnnualExpenditures(testStudy.Components));
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void HOAFees100units5000Expenses()
        {
            ReserveStudyService testService = new ReserveStudyService();
            decimal result = testService.GetMonthlyHOAFeePerUnit(5000m, 100);
            decimal expected = 5000.0m/(30*12)/(100);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void AnnualExpendituresEmptyComponentList()
        {
            ReserveStudyService testService = new ReserveStudyService();
            ReserveStudy testStudy = new ReserveStudy();
            List<decimal> result = testService.GetAnnualExpenditures(testStudy.Components);
            List<decimal> expected = new List<decimal>();
            for (int i = 0; i < 30; i++)
            {
                expected.Add(0);
            }
            CollectionAssert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TotalExpendituresEmptyComponentList()
        {
            ReserveStudyService testService = new ReserveStudyService();
            ReserveStudy testStudy = new ReserveStudy();
            decimal result = testService.GetTotalExpenditures(testService.GetAnnualExpenditures(testStudy.Components));
            decimal expected = 0;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void HOAFeesNoUnitsDivByZero()
        {
            ReserveStudyService testService = new ReserveStudyService();
            Assert.Throws<ArgumentException>(() => testService.GetMonthlyHOAFeePerUnit(5000, 0));
        }
    }
}