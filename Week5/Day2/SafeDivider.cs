using System;

namespace Practice
{
    class Calculator
    {
        public void Divide(int numerator, int denominator)
        {
            try
            {
                int result = numerator / denominator;
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero");
            }
            finally
            {
                Console.WriteLine("Operation completed safely");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            int num, den;

            Console.Write("Enter Numerator: ");
            if (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
                return;
            }

            Console.Write("Enter Denominator: ");
            if (!int.TryParse(Console.ReadLine(), out den))
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
                return;
            }

            calc.Divide(num, den);

            Console.WriteLine("Program continues running...");
        }
    }
}