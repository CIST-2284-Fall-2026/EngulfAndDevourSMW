using System.IO.Pipelines;
using Common.Models;
using Common.Services;

namespace Tests.Common.Services
{
    [TestClass]
    public sealed class BalanceSheetTests
    {
        [TestMethod]
        // This tests the total assets calculation with 10 items totalling 10000
        public void TotalAssets10Items10000Total()
        {
            BalanceSheetService testClass = new BalanceSheetService();
            BalanceSheet testSheet = new BalanceSheet();
            for (int i = 0; i < 10; i++)
            {
                LineItem item = new LineItem();
                item.Name = $"Item # {i + 1}";
                item.Amount = 1000.0m; 
                testSheet.Assets.Add(item);
            }
            decimal result = testClass.CalculateTotalAssets(testSheet.Assets);
            decimal expected = 10000.0m;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        // This tests the total liabilities calculation with 10 items totalling 10000
        public void TotalLiabilities10Items10000Total()
        {
            BalanceSheetService testClass = new BalanceSheetService();
            BalanceSheet testSheet = new BalanceSheet();
            for (int i = 0; i < 10; i++)
            {
                LineItem item = new LineItem();
                item.Name = $"Item # {i + 1}";
                item.Amount = 1000.0m; 
                testSheet.Liabilities.Add(item);
            }
            decimal result = testClass.CalculateTotalLiabilities(testSheet.Liabilities);
            decimal expected = 10000.0m;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        // This tests the total equity caclcuation with 10000 in assets and 5000 in liabilities
        public void Assets10000Liabilities5000TotalEquity5000()
        {
            BalanceSheetService testClass = new BalanceSheetService();
            BalanceSheet testSheet = new BalanceSheet();
            for (int i = 0; i < 10; i++)
            {
                LineItem item = new LineItem();
                item.Name = $"Item # {i + 1}";
                item.Amount = 1000.0m; 
                testSheet.Assets.Add(item);
            }
            for (int i = 0; i < 10; i++)
            {
                LineItem item = new LineItem();
                item.Name = $"Item # {i + 1}";
                item.Amount = 500.0m; 
                testSheet.Liabilities.Add(item);
            }
            decimal result = testClass.CalculateEquity(testClass.CalculateTotalAssets(testSheet.Assets), testClass.CalculateTotalLiabilities(testSheet.Liabilities));
            decimal expected = 5000.0m;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        // This tests the total assets calcuation with an empty assets list
        public void TotalAssetsEmptyList()
        {
            BalanceSheetService testClass = new BalanceSheetService();
            BalanceSheet testSheet = new BalanceSheet();
            decimal result = testClass.CalculateTotalAssets(testSheet.Assets);
            decimal expected = 0m;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        // This tests the total liabilities calculation with an empty liabilities list
        public void TotalLiabilitiesEmptyList()
        {
            BalanceSheetService testClass = new BalanceSheetService();
            BalanceSheet testSheet = new BalanceSheet();
            decimal result = testClass.CalculateTotalLiabilities(testSheet.Liabilities);
            decimal expected = 0m;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        // This tests the total equity calculation with empty asset and liability lists
        public void TotalEquityEmptyLists()
        {
            BalanceSheetService testClass = new BalanceSheetService();
            BalanceSheet testSheet = new BalanceSheet();
            decimal result = testClass.CalculateEquity(testClass.CalculateTotalAssets(testSheet.Assets), testClass.CalculateTotalLiabilities(testSheet.Liabilities));
            decimal expected = 0m;
            Assert.AreEqual(expected, result);
        }
    }
}