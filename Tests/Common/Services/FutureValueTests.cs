using Common.Models;

namespace Tests.Common.Services;

[TestClass]
public sealed class FutureValueTests
{
    // The first method tests a typical case of typical values. I ran the calculation on my calculator and compared the rounded values.
    [TestMethod]
    public void Principal1000Interest1pctYears10Compounds4()
    {
        decimal expected = 1105.03M;
        FutureValue testClass = new FutureValue();
        testClass.Principal = 1000;
        testClass.InterestRate = 1;
        testClass.Years = 10;
        testClass.CompoundsPerYear = 4;
        decimal actual = Math.Round(testClass.FutureVal, 2);
        Assert.AreEqual(expected, actual);
    }

    // validation should prevent the remaining cases, but I am testing them anyway.
    // Tests results for a Principal value of zero. Sould return zero.
    [TestMethod]
    public void ZeroPrincipalTest()
    {
        decimal expected = 0.0M;
        FutureValue testClass = new FutureValue();
        testClass.Principal = 0;
        testClass.InterestRate = 1;
        testClass.Years = 1;
        testClass.CompoundsPerYear = 1;
        decimal actual = testClass.FutureVal;
        Assert.AreEqual(expected, actual);
    }

    // Tests results for an Interest Rate value of zero. Should return the value of the Principal.
    [TestMethod]
    public void ZeroInterestRateTest()
    {
        decimal expected = 1.0M;
        FutureValue testClass = new FutureValue();
        testClass.Principal = 1;
        testClass.InterestRate = 0;
        testClass.Years = 1;
        testClass.CompoundsPerYear = 1;
        decimal actual = testClass.FutureVal;
        Assert.AreEqual(expected, actual);
    }

    // Tests results for a value of zero years. Should return the value of the Principal.
    [TestMethod]
    public void ZeroYearsTest()
    {
        decimal expected = 1.0M;
        FutureValue testClass = new FutureValue();
        testClass.Principal = 1;
        testClass.InterestRate = 1;
        testClass.Years = 0;
        testClass.CompoundsPerYear = 1;
        decimal actual = testClass.FutureVal;
        Assert.AreEqual(expected, actual);
    }

    // Tests results for zero compounds per year. This would normally result in division by zero, however the Calculate method simply sets Future Value to zero in this case. Thus, this should return zero.
    [TestMethod]
    public void ZeroCompoundsPerYearTest()
    {
        decimal expected = 0.0M;
        FutureValue testClass = new FutureValue();
        testClass.Principal = 1;
        testClass.InterestRate = 1;
        testClass.Years = 1;
        testClass.CompoundsPerYear = 0;
        decimal actual = testClass.FutureVal;
        Assert.AreEqual(expected, actual);
    }

    // The remaining tests are for any of the variable values being negative. This would normally result in a negaive value, however the Calculate method simply sets future value to zero if any of these values are negative, as a negative future value wouldn't be very useful. Each of these should result in a future value of zero.
    [TestMethod]
    public void NegativePrincipalTest()
    {
        decimal expected = 0.0M;
        FutureValue testClass = new FutureValue();
        testClass.Principal = -1;
        testClass.InterestRate = 1;
        testClass.Years = 1;
        testClass.CompoundsPerYear = 1;
        decimal actual = testClass.FutureVal;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void NegativeInterestRateTest()
    {
        decimal expected = 0.0M;
        FutureValue testClass = new FutureValue();
        testClass.Principal = 1;
        testClass.InterestRate = -1;
        testClass.Years = 1;
        testClass.CompoundsPerYear = 1;
        decimal actual = testClass.FutureVal;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void NegativeYearsTest()
    {
        decimal expected = 0.0M;
        FutureValue testClass = new FutureValue();
        testClass.Principal = 1;
        testClass.InterestRate = 1;
        testClass.Years = -1;
        testClass.CompoundsPerYear = 1;
        decimal actual = testClass.FutureVal;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void NegativeCompoundsPerYearTest()
    {
        decimal expected = 0.0M;
        FutureValue testClass = new FutureValue();
        testClass.Principal = 1;
        testClass.InterestRate = 1;
        testClass.Years = 1;
        testClass.CompoundsPerYear = -1;
        decimal actual = testClass.FutureVal;
        Assert.AreEqual(expected, actual);
    }
}

