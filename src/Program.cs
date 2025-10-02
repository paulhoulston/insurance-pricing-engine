using System;
using System.IO;
using System.Text.Json;

namespace MyDotNetConsoleApp
{
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

            decimal basePremium = AppleInsuranceCalculator.CalculatePremium(input);

            Console.WriteLine($"Final insurance premium: £{basePremium:F2}");
        }
    }
}