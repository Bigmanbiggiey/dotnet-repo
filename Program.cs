using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("🧮 Advanced C# Calculator");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Available operations: +  -  *  /  %  ^  √");
        Console.WriteLine("Note: '√' only uses the first number");
        Console.WriteLine();

        // Get first number
        Console.Write("Enter first number: ");
        string? input1 = Console.ReadLine();
        if (!double.TryParse(input1, out double num1))
        {
            Console.WriteLine("❌ Invalid number input!");
            return;
        }

        // Get operator
        Console.Write("Enter an operator (+, -, *, /, %, ^, √): ");
        string? inputOp = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inputOp))
        {
            Console.WriteLine("❌ No operator provided!");
            return;
        }

        string op = inputOp.Trim();

        double num2 = 0;
        double result = 0;
        bool validOp = true;

        // For everything except square root, ask for a second number
        if (op != "√")
        {
            Console.Write("Enter second number: ");
            string? input2 = Console.ReadLine();
            if (!double.TryParse(input2, out num2))
            {
                Console.WriteLine("❌ Invalid number input!");
                return;
            }
        }

        // Perform operation
        switch (op)
        {
            case "+":
                result = num1 + num2;
                break;

            case "-":
                result = num1 - num2;
                break;

            case "*":
                result = num1 * num2;
                break;

            case "/":
                if (num2 == 0)
                {
                    Console.WriteLine("❌ Cannot divide by zero!");
                    return;
                }
                result = num1 / num2;
                break;

            case "%":
                result = num1 % num2;
                break;

            case "^":
                result = Math.Pow(num1, num2);
                break;

            case "√":
                if (num1 < 0)
                {
                    Console.WriteLine("❌ Cannot take square root of a negative number!");
                    return;
                }
                result = Math.Sqrt(num1);
                break;

            default:
                Console.WriteLine("❌ Invalid operator!");
                validOp = false;
                break;
        }

        if (validOp)
        {
            if (op == "√")
                Console.WriteLine($"✅ Result: √{num1} = {result}");
            else
                Console.WriteLine($"✅ Result: {num1} {op} {num2} = {result}");
        }
    }
}
