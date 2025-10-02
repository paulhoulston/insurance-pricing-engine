using Xunit;
using MyDotNetConsoleApp;

public class AppleInsuranceCalculatorTests
{
    [Fact]
    public void Calculates_Base_Premium_Correctly()
    {
        var input = new AppleInsuranceParams { NumberOfApples = 100, Month = 6, DistanceMiles = 50, LockedCompoundWithCCTV = false };
        double expected = 100 * 0.01 * 0.90; // April-Sept loading
        double actual = AppleInsuranceCalculator.CalculatePremium(input);
        Assert.Equal(expected, actual, 2);
    }

    [Fact]
    public void Applies_5Percent_Discount_For_1000_To_10000_Apples()
    {
        var input = new AppleInsuranceParams { NumberOfApples = 5000, Month = 2, DistanceMiles = 50, LockedCompoundWithCCTV = false };
        double expected = 5000 * 0.01 * 0.95 * 1.10; // 5% discount, Jan-Mar loading
        double actual = AppleInsuranceCalculator.CalculatePremium(input);
        Assert.Equal(expected, actual, 2);
    }

    [Fact]
    public void Applies_8Percent_Discount_For_Over_10000_Apples()
    {
        var input = new AppleInsuranceParams { NumberOfApples = 15000, Month = 2, DistanceMiles = 50, LockedCompoundWithCCTV = false };
        double expected = 15000 * 0.01 * 0.92 * 1.10; // 8% discount, Jan-Mar loading
        double actual = AppleInsuranceCalculator.CalculatePremium(input);
        Assert.Equal(expected, actual, 2);
    }

    [Fact]
    public void Applies_Distance_Loading_If_Over_100_Miles()
    {
        var input = new AppleInsuranceParams { NumberOfApples = 3000, Month = 5, DistanceMiles = 150, LockedCompoundWithCCTV = false };
        double expected = 3000 * 0.01 * 0.90 + 3 * 5.00; // April-Sept loading, 3*£5 loading
        double actual = AppleInsuranceCalculator.CalculatePremium(input);
        Assert.Equal(expected, actual, 2);
    }

    [Fact]
    public void Applies_LockedCompound_Discount_And_Caps_It()
    {
        var input = new AppleInsuranceParams { NumberOfApples = 10000, Month = 5, DistanceMiles = 50, LockedCompoundWithCCTV = true };
        double discount = Math.Min(20 * 0.20, 3.50); // 20 lots of 500 apples, capped at £3.50
        double expected = 10000 * 0.01 * 0.95 * 0.90 - discount;
        double actual = AppleInsuranceCalculator.CalculatePremium(input);
        Assert.Equal(expected, actual, 2);
    }
}