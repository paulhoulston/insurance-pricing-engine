namespace MyDotNetConsoleApp
{
    public static class AppleInsuranceCalculator
    {
        public static double CalculatePremium(AppleInsuranceParams input)
        {
            double basePremium = input.NumberOfApples * 0.01;

            if (input.NumberOfApples >= 1000 && input.NumberOfApples <= 10000)
                basePremium *= 0.95;
            else if (input.NumberOfApples > 10000)
                basePremium *= 0.92;

            if (input.Month >= 1 && input.Month <= 3)
                basePremium *= 1.10;
            else if (input.Month >= 4 && input.Month <= 9)
                basePremium *= 0.90;

            if (input.DistanceMiles > 100)
            {
                int thousands = input.NumberOfApples / 1000;
                basePremium += thousands * 5.00;
            }

            if (input.LockedCompoundWithCCTV)
            {
                int fiveHundreds = input.NumberOfApples / 500;
                double discount = System.Math.Min(fiveHundreds * 0.20, 3.50);
                basePremium -= discount;
            }

            return basePremium;
        }
    }
}