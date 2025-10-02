using Xunit;
using MyDotNetConsoleApp;

public class AppleInsuranceCalculatorTests
{
    [Fact]
    public void Calculates_Base_Premium_Correctly()
    {
        var input = new AppleInsuranceParams { NumberOfApples = 100, Month = 6, DistanceMiles = 50, LockedCompoundWithCCTV = false };
        decimal expected = 100 * 0.01m * 0.90m;
        decimal actual = AppleInsuranceCalculator.CalculatePremium(input);
        Assert.Equal(expected, actual, 2);
    }

    [Fact]
    public void Applies_5Percent_Discount_For_1000_To_10000_Apples()
    {
        var input = new AppleInsuranceParams { NumberOfApples = 5000, Month = 2, DistanceMiles = 50, LockedCompoundWithCCTV = false };
        decimal expected = 5000 * 0.01m * 0.95m * 1.10m;
        decimal actual = AppleInsuranceCalculator.CalculatePremium(input);
        Assert.Equal(expected, actual, 2);
    }

    [Fact]
    public void Applies_8Percent_Discount_For_Over_10000_Apples()
    {
        var input = new AppleInsuranceParams { NumberOfApples = 15000, Month = 2, DistanceMiles = 50, LockedCompoundWithCCTV = false };
        decimal expected = 15000 * 0.01m * 0.92m * 1.10m;
        decimal actual = AppleInsuranceCalculator.CalculatePremium(input);
        Assert.Equal(expected, actual, 2);
    }

    [Fact]
    public void Applies_Distance_Loading_If_Over_100_Miles()
    {
        var input = new AppleInsuranceParams { NumberOfApples = 3000, Month = 5, DistanceMiles = 150, LockedCompoundWithCCTV = false };
        decimal expected = 3000 * 0.01m * 0.90m + 3 * 5.00m;
        decimal actual = AppleInsuranceCalculator.CalculatePremium(input);
        Assert.Equal(expected, actual, 2);
    }

    [Fact]
    public void Applies_LockedCompound_Discount_And_Caps_It()
    {
        var input = new AppleInsuranceParams { NumberOfApples = 10000, Month = 5, DistanceMiles = 50, LockedCompoundWithCCTV = true };
        decimal discount = System.Math.Min(20 * 0.20m, 3.50m);
        decimal expected = 10000 * 0.01m * 0.95m * 0.90m - discount;
        decimal actual = AppleInsuranceCalculator.CalculatePremium(input);
        Assert.Equal(expected, actual, 2);
    }
}