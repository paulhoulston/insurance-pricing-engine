namespace MyDotNetConsoleApp
{
    public class AppleInsuranceParams
    {
        public int NumberOfApples { get; set; }
        public int Month { get; set; }
        public decimal DistanceMiles { get; set; }
        public bool LockedCompoundWithCCTV { get; set; }
    }

    public static class AppleInsuranceCalculator
    {
        public static decimal CalculatePremium(AppleInsuranceParams input)
        {
            double basePremium = input.NumberOfApples * 0.01;

            // Distance loading (applied first)
            if (input.DistanceMiles > 100)
            {
                int thousands = input.NumberOfApples / 1000;
                basePremium += thousands * 5.00;
            }

            // Discount for number of apples
            if (input.NumberOfApples >= 1000 && input.NumberOfApples <= 10000)
                basePremium *= 0.95;
            else if (input.NumberOfApples > 10000)
                basePremium *= 0.92;

            // Seasonal loading
            if (input.Month >= 1 && input.Month <= 3)
                basePremium *= 1.10;
            else if (input.Month >= 4 && input.Month <= 9)
                basePremium *= 0.90;

            // Locked compound discount
            if (input.LockedCompoundWithCCTV)
            {
                int fiveHundreds = input.NumberOfApples / 500;
                double discount = System.Math.Min(fiveHundreds * 0.20, 3.50);
                basePremium -= discount;
            }

            return (decimal)basePremium;
        }
    }
}