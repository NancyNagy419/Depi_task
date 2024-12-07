using System;

class Program
{
    static void Main()
    {
        // problem 1
        Console.Write("Enter a positive integer: ");
        if (int.TryParse(Console.ReadLine(), out int inputNumber) && inputNumber > 0)
        {
            Console.WriteLine($"Numbers from 1 to {inputNumber}:");
            PrintNumbersInRange(inputNumber);
        }
        else
        {
            Console.WriteLine("Please enter a valid positive integer.");
        }

        // problem 2
        Console.Write("Enter an integer: ");
        if (int.TryParse(Console.ReadLine(), out int inputNum))
        {
            Console.WriteLine($"Multiplication table for {inputNum}:");
            PrintMultiplicationTable(inputNum);
        }
        else
        {
            Console.WriteLine("Please enter a valid integer.");
        }

        // problem 3
        Console.Write("Enter a number: ");
        if (int.TryParse(Console.ReadLine(), out int inputN) && inputN >= 1)
        {
            Console.WriteLine($"Even numbers between 1 and {inputN}:");
            PrintEvenNumbers(inputN);
        }
        else
        {
            Console.WriteLine("Please enter a valid positive integer.");
        }

        // problem 4
        Console.Write("Enter the base number: ");
        if (int.TryParse(Console.ReadLine(), out int baseNumber))
        {
            Console.Write("Enter the exponent number: ");
            if (int.TryParse(Console.ReadLine(), out int exponentNumber))
            {
                long result = ComputeExponentiation(baseNumber, exponentNumber);
                Console.WriteLine($"{baseNumber}^{exponentNumber} = {result}");
            }
            else
            {
                Console.WriteLine("Please enter a valid integer for the exponent.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid integer for the base.");
        }

        // problem 5
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        string reversedString = ReverseString(input);
        Console.WriteLine($"Reversed string: \"{reversedString}\"");


        // problem 6
        Console.Write("Enter an integer: ");
        if (int.TryParse(Console.ReadLine(), out int inputNumb))
        {
            int reversedNumber = ReverseInteger(inputNumb);
            Console.WriteLine($"Reversed integer: {reversedNumb}");
        }
        else
        {
            Console.WriteLine("Please enter a valid integer.");
        }

        // problem 7
        Console.Write("Enter the number of elements in the array: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            int[] array = new int[n];
            Console.WriteLine($"Enter {n} integers:");
            for (int i = 0; i < n; i++)
            {
                if (int.TryParse(Console.ReadLine(), out int element))
                {
                    array[i] = element;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter integers only.");
                    i--;
                }
            }
            int longestDistance = FindLongestDistance(array);
            Console.WriteLine($"The longest distance between matching elements is: {longestDistance}");
        }
        else
        {
            Console.WriteLine("Please enter a valid positive integer for the size of the array.");
        }

        // problem 8
        Console.Write("Enter a sentence: ");
        string inputt = Console.ReadLine();
        string reversedSentence = string.Join(" ", inputt.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
        Console.WriteLine(reversedSentence);

    }

    static void PrintNumbersInRange(int number)
    {
        for (int i = 1; i <= number; i++)
        {
            if (i < number)
            {
                Console.Write(i + ", ");
            }
            else
            {
                Console.Write(i);
            }
        }
        Console.WriteLine();
    }

    static void PrintMultiplicationTable(int number)
    {
        for (int i = 1; i <= 12; i++)
        {
            int result = number * i;
            if (i < 12)
            {
                Console.Write(result + ", ");
            }
            else
            {
                Console.Write(result);
            }
        }
        Console.WriteLine();
    }

    static void PrintEvenNumbers(int number)
    {
        for (int i = 2; i <= number; i += 2)
        {
            if (i < number)
            {
                Console.Write(i + ", ");
            }
            else
            {
                Console.Write(i);
            }
        }
        Console.WriteLine();
    }

    static long ComputeExponentiation(int baseNum, int exponent)
    {
        long result = 1;
        for (int i = 0; i < exponent; i++)
        {
            result *= baseNum;
        }
        return result;
    }

    static string ReverseString(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    static int ReverseInteger(int number)
    {
        int reversed = 0;
        int isNegative = number < 0 ? -1 : 1;
        number = Math.Abs(number);

        while (number != 0)
        {
            int digit = number % 10;
            reversed = reversed * 10 + digit;
            number /= 10;
        }

        return reversed * isNegative;
    }

    static int FindLongestDistance(int[] array)
    {
        Dictionary<int, int> indexMap = new Dictionary<int, int>();
        int longestDistance = -1;

        for (int i = 0; i < array.Length; i++)
        {
            if (indexMap.ContainsKey(array[i]))
            {
                int distance = i - indexMap[array[i]] - 1;
                longestDistance = Math.Max(longestDistance, distance);
            }
            else
            {
                indexMap[array[i]] = i;
            }
        }
        return longestDistance;
    }
}
