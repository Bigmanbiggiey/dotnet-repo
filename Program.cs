using System;
using System.Collections.Generic;

namespace MyConsoleApp
{
    class Program
    {
        static List<string> history = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Advanced .NET Calculator!");
            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Calculator");
                Console.WriteLine("2. View History");
                Console.WriteLine("3. Clear History");
                Console.WriteLine("4. Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunCalculator();
                        break;
                    case "2":
                        ShowHistory();
                        break;
                    case "3":
                        ClearHistory();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void RunCalculator()
        {
            try
            {
                Console.Write("\nEnter first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter operator (+, -, *, /, ^): ");
                string op = Console.ReadLine();

                Console.Write("Enter second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                double result = op switch
                {
                    "+" => num1 + num2,
                    "-" => num1 - num2,
                    "*" => num1 * num2,
                    "/" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException(),
                    "^" => Math.Pow(num1, num2),
                    _ => throw new InvalidOperationException("Invalid operator")
                };

                string log = $"{num1} {op} {num2} = {result}";
                history.Add(log);
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ShowHistory()
        {
            Console.WriteLine("\nCalculation History:");
            if (history.Count == 0)
            {
                Console.WriteLine("No history available.");
            }
            else
            {
                foreach (var entry in history)
                {
                    Console.WriteLine(entry);
                }
            }
        }

        static void ClearHistory()
        {
            history.Clear();
            Console.WriteLine("History cleared.");
        }
    }
}
