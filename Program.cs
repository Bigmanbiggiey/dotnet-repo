using System;
using System.Collections.Generic;
using System.Globalization;

namespace MyConsoleApp
{
    class Program
    {
        static List<string> history = new List<string>();

        static void Main()
        {
            Console.WriteLine("=== Advanced Calculator (.NET) ===\n");

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Basic Operation (+ - * /)");
                Console.WriteLine("2. Power");
                Console.WriteLine("3. Square Root");
                Console.WriteLine("4. Trigonometry (sin, cos, tan)");
                Console.WriteLine("5. Show History");
                Console.WriteLine("6. Exit");

                Console.Write("\nEnter choice (1-6): ");
                string? choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        PerformBasicOperation();
                        break;
                    case "2":
                        PerformPower();
                        break;
                    case "3":
                        PerformSqrt();
                        break;
                    case "4":
                        PerformTrig();
                        break;
                    case "5":
                        ShowHistory();
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.\n");
                        break;
                }
            }
        }

        static void PerformBasicOperation()
        {
            double num1 = ReadDouble("Enter first number: ");
            double num2 = ReadDouble("Enter second number: ");
            Console.Write("Enter operator (+ - * /): ");
            string? op = Console.ReadLine();

            double result = 0;
            string operation = "";

            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    operation = $"{num1} + {num2} = {result}";
                    break;
                case "-":
                    result = num1 - num2;
                    operation = $"{num1} - {num2} = {result}";
                    break;
                case "*":
                    result = num1 * num2;
                    operation = $"{num1} * {num2} = {result}";
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        operation = $"{num1} / {num2} = {result}";
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide by zero.\n");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operator.\n");
                    return;
            }

            Console.WriteLine($"Result: {result}\n");
            history.Add(operation);
        }

        static void PerformPower()
        {
            double baseNum = ReadDouble("Enter base number: ");
            double exponent = ReadDouble("Enter exponent: ");
            double result = Math.Pow(baseNum, exponent);
            string operation = $"{baseNum} ^ {exponent} = {result}";
            Console.WriteLine($"Result: {result}\n");
            history.Add(operation);
        }

        static void PerformSqrt()
        {
            double num = ReadDouble("Enter number: ");
            if (num < 0)
            {
                Console.WriteLine("Cannot compute square root of a negative number.\n");
                return;
            }
            double result = Math.Sqrt(num);
            string operation = $"√{num} = {result}";
            Console.WriteLine($"Result: {result}\n");
            history.Add(operation);
        }

        static void PerformTrig()
        {
            Console.Write("Enter function (sin, cos, tan): ");
            string? func = Console.ReadLine()?.ToLower();
            double angle = ReadDouble("Enter angle in degrees: ");
            double radians = angle * Math.PI / 180;
            double result = 0;
            string operation = "";

            switch (func)
            {
                case "sin":
                    result = Math.Sin(radians);
                    operation = $"sin({angle}) = {result}";
                    break;
                case "cos":
                    result = Math.Cos(radians);
                    operation = $"cos({angle}) = {result}";
                    break;
                case "tan":
                    result = Math.Tan(radians);
                    operation = $"tan({angle}) = {result}";
                    break;
                default:
                    Console.WriteLine("Invalid function.\n");
                    return;
            }

            Console.WriteLine($"Result: {result}\n");
            history.Add(operation);
        }

        static void ShowHistory()
        {
            Console.WriteLine("=== Calculation History ===");
            if (history.Count == 0)
            {
                Console.WriteLine("No history yet.\n");
            }
            else
            {
                foreach (var entry in history)
                {
                    Console.WriteLine(entry);
                }
                Console.WriteLine();
            }
        }

        static double ReadDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                {
                    return value;
                }
                Console.WriteLine("Invalid number. Try again.");
            }
        }
    }
}
