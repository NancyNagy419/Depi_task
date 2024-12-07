using System;

class Program
{
    static void Main()
    {
        // problem 1
        try
        {
            Console.Write("Enter the first number: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int num2 = int.Parse(Console.ReadLine());
            int result = num1 / num2;
            Console.WriteLine($"The result of {num1} / {num2} is: {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid integers.");
        }
        finally
        {
            Console.WriteLine("Operation complete.");
        }

        // problem 2
        TestDefensiveCode();

        // problem 3
        int? nullableInt = null;
        int defaultValue = nullableInt ?? 100;
        Console.WriteLine($"Value of nullableInt (with ??): {defaultValue}");
        Console.WriteLine($"Does nullableInt have a value? {nullableInt.HasValue}");
        nullableInt = 42;
        Console.WriteLine($"Does nullableInt have a value now? {nullableInt.HasValue}");
        Console.WriteLine($"Value of nullableInt: {nullableInt.Value}");

        // problem 4
        int[] numbers = new int[5] { 10, 20, 30, 40, 50 };

        try
        {
            Console.WriteLine("Accessing index 10...");
            int value = numbers[10];
            Console.WriteLine($"Value at index 10: {value}");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Error: Tried to access an index out of bounds.");
            Console.WriteLine($"Exception message: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Array access attempt complete.");
        }

        // problem 5
        int[,] array = new int[3, 3];
        Console.WriteLine("Enter values for a 3x3 matrix:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Enter value for element [{i},{j}]: ");
                array[i, j] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine("\nMatrix:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nSum of rows:");
        for (int i = 0; i < 3; i++)
        {
            int rowSum = 0;
            for (int j = 0; j < 3; j++)
            {
                rowSum += array[i, j];
            }
            Console.WriteLine($"Row {i + 1} sum: {rowSum}");
        }
        Console.WriteLine("\nSum of columns:");
        for (int j = 0; j < 3; j++)
        {
            int colSum = 0;
            for (int i = 0; i < 3; i++)
            {
                colSum += array[i, j];
            }
            Console.WriteLine($"Column {j + 1} sum: {colSum}");
        }

        // problem 6
        int[][] jaggedArray = new int[3][];
        jaggedArray[0] = new int[2];
        jaggedArray[1] = new int[4];
        jaggedArray[2] = new int[3];

        Console.WriteLine("Enter values for the jagged array:");
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            Console.WriteLine($"Row {i + 1}:");
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write($"Enter value for element [{i}][{j}]: ");
                jaggedArray[i][j] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine("\nValues in the jagged array:");
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            Console.Write($"Row {i + 1}: ");
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + " ");
            }
            Console.WriteLine();
        }

        // problem 7
        string? nullableString = null;
        Console.WriteLine("Would you like to provide a value? (yes/no): ");
        string userResponse = Console.ReadLine()!;

        if (userResponse.ToLower() == "yes")
        {
            Console.Write("Enter a value for the string: ");
            nullableString = Console.ReadLine();
        }
        if (nullableString != null)
        {
            Console.WriteLine($"You entered: {nullableString}");
        }
        else
        {
            Console.WriteLine("You chose not to provide a value.");
        }
        Console.WriteLine("End of program. Nullable string: " + nullableString!);

        // problem 8
        try
        {
            int valueType = 42;
            object boxedValue = valueType;
            Console.WriteLine($"Boxing: Value type {valueType} is boxed into an object.");

            int unboxedValue = (int)boxedValue;
            Console.WriteLine($"Unboxing: Boxed object is cast back to int with value {unboxedValue}.");
            Console.WriteLine("Attempting invalid unboxing...");
            object anotherBoxedValue = 3.14;
            int invalidUnboxedValue = (int)anotherBoxedValue;
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine("Error: Invalid unboxing attempted.");
            Console.WriteLine($"Exception message: {ex.Message}");
        }

        // problem 9
        int sum, product;
        SumAndMultiply(5, 10, out sum, out product);
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Product: {product}");


        // problem 10
        PrintMultipleTimes("Hello");
        PrintMultipleTimes("Welcome", 3);
        PrintMultipleTimes(times: 4, text: "Named Parameters");

        // problem 11
        int?[] nullableArray = new int?[5];
        nullableArray[0] = 1;
        nullableArray[1] = null;
        nullableArray[2] = 3;
        nullableArray[3] = 4;
        nullableArray[4] = null;
        Console.WriteLine("Accessing elements using null propagation:");

        for (int i = 0; i < nullableArray.Length; i++)
        {
            Console.WriteLine($"Element at index {i}: {nullableArray[i]?.ToString() ?? "null"}");
        }
        int? summtion = GetSumOfElements(nullableArray);
        Console.WriteLine($"\nSum of non-null elements: {summtion?.ToString() ?? "null"}");


        // problem 12
        Console.Write("Enter a day of the week (e.g., Monday): ");
        string day = Console.ReadLine();
        int dayNumber = day switch
        {
            "Monday" => 1,
            "Tuesday" => 2,
            "Wednesday" => 3,
            "Thursday" => 4,
            "Friday" => 5,
            "Saturday" => 6,
            "Sunday" => 7,
            _ => 0
        };
        if (dayNumber > 0)
        {
            Console.WriteLine($"{day} corresponds to number: {dayNumber}");
        }
        else
        {
            Console.WriteLine("Invalid day entered. Please enter a valid day of the week.");
        }


        // problem 13
        int sum1 = SumArray(1, 2, 3, 4, 5);
        Console.WriteLine($"Sum of individual values: {sum1}");

        int[] number = { 10, 20, 30, 40 };
        int sum2 = SumArray(number);
        Console.WriteLine($"Sum of array values: {sum2}");


    }

    
    static void TestDefensiveCode()
    {
        int x, y;

        while (true)
        {
            try
            {
                Console.Write("Enter a positive integer for X: ");
                x = int.Parse(Console.ReadLine());
                if (x <= 0)
                {
                    throw new ArgumentException("X must be a positive integer.");
                }
                Console.Write("Enter a positive integer greater than 1 for Y: ");
                y = int.Parse(Console.ReadLine());
                if (y <= 1)
                {
                    throw new ArgumentException("Y must be a positive integer greater than 1.");
                }
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter valid integers.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        Console.WriteLine($"You entered valid values: X = {x}, Y = {y}");
    }
    static void SumAndMultiply(int num1, int num2, out int sum, out int product)
    {
        sum = num1 + num2;
        product = num1 * num2;

    }
    static void PrintMultipleTimes(string text, int times = 5)
    {
        for (int i = 0; i < times; i++)
        {
            Console.WriteLine(text);
        }
    }

    static int? GetSumOfElements(int?[] array)
    {
        int? summtion = 0;
        foreach (var item in array)
        {
            summtion += item ?? 0;
        }
        return summtion;
    }


    static int SumArray(params int[] numbers)
    {
        int s = 0;
        foreach (var n in numbers)
        {
            s += n;
        }
        return s;
    }
}
