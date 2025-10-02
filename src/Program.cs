using System;
using System.IO;
using System.Text.Json;

namespace MyDotNetConsoleApp
{
    public class AppleInsuranceParams
    {
        public int NumberOfApples { get; set; }
        public int Month { get; set; } // 1 = January, ..., 12 = December
        public double DistanceMiles { get; set; }
        public bool LockedCompoundWithCCTV { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: dotnet run <input.json>");
                return;
            }

            var json = File.ReadAllText(args[0]);
            var input = JsonSerializer.Deserialize<AppleInsuranceParams>(json);

            double basePremium = input.NumberOfApples * 0.01;

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

            // Distance loading
            if (input.DistanceMiles > 100)
            {
                int thousands = input.NumberOfApples / 1000;
                basePremium += thousands * 5.00;
            }

            // Locked compound discount
            if (input.LockedCompoundWithCCTV)
            {
                int fiveHundreds = input.NumberOfApples / 500;
                double discount = Math.Min(fiveHundreds * 0.20, 3.50);
                basePremium -= discount;
            }

            Console.WriteLine($"Final insurance premium: £{basePremium:F2}");
        }
    }
}