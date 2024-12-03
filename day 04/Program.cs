using System;

class Program
{
    static void Main()
    {
        // problem 1
        // Initializing a one-dimensional array using `new int[size]`
        int[] array1 = new int[5];
        for (int i = 0; i < array1.Length; i++)
        {
            array1[i] = i * 2;
        }
        Console.WriteLine("Array1 (initialized with new int[size]):");
        foreach (var item in array1)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        // Initializing a one-dimensional array using an initializer list
        int[] array2 = { 10, 20, 30, 40, 50 };
        Console.WriteLine("Array2 (initialized with initializer list):");
        foreach (var item in array2)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        // Initializing a one-dimensional array using array syntax sugar
        int[] array3 = new[] { 100, 200, 300, 400, 500 };
        Console.WriteLine("Array3 (initialized with array syntax sugar):");
        foreach (var item in array3)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        // Demonstrating an IndexOutOfRangeException
        try
        {
            Console.WriteLine("Attempting to access an out-of-range index in Array1...");
            Console.WriteLine(array1[array1.Length]); // This will throw an exception
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
        }
        Console.WriteLine();

        //problem 2
        int[] arr1 = { 1, 2, 3, 4, 5 };
        int[] arr2;

        arr2 = arr1;
        Console.WriteLine("Before modifying arr2 (Shallow Copy):");
        PrintArrays(arr1, arr2);

        arr2[0] = 99;
        Console.WriteLine("\nAfter modifying arr2 (Shallow Copy):");
        PrintArrays(arr1, arr2);

        int[] arr3 = (int[])arr1.Clone();
        Console.WriteLine("\nBefore modifying arr3 (Deep Copy):");
        PrintArrays(arr1, arr3);

        arr3[1] = 42;
        Console.WriteLine("\nAfter modifying arr3 (Deep Copy):");
        PrintArrays(arr1, arr3);

        static void PrintArrays(int[] array1, int[] array2)
        {
            Console.WriteLine("arr1: " + string.Join(", ", array1));
            Console.WriteLine("arr2: " + string.Join(", ", array2));
        }
        Console.WriteLine();

        // problem 3
        int[,] grades = new int[3, 3];

        Console.WriteLine("Enter grades for 3 students in 3 subjects:");
        for (int student = 0; student < 3; student++)
        {
            Console.WriteLine($"\nEnter grades for Student {student + 1}:");
            for (int subject = 0; subject < 3; subject++)
            {
                Console.Write($"Subject {subject + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out grades[student, subject]) || grades[student, subject] < 0 || grades[student, subject] > 100)
                {
                    Console.Write("Invalid input. Please enter a valid grade (0-100): ");
                }
            }
        }

        Console.WriteLine("\nGrades for each student:");
        for (int student = 0; student < 3; student++)
        {
            Console.WriteLine($"Student {student + 1}:");
            for (int subject = 0; subject < 3; subject++)
            {
                Console.WriteLine($"  Subject {subject + 1}: {grades[student, subject]}");
            }
        }
        Console.WriteLine();

        // problem 4
        int[] originalArray = { 5, 2, 9, 1, 6 };

        Console.WriteLine("Original Array: " + string.Join(", ", originalArray));

        Array.Sort(originalArray);
        Console.WriteLine("\nAfter Array.Sort():");
        Console.WriteLine("Array sorted in ascending order: " + string.Join(", ", originalArray));

        Array.Reverse(originalArray);
        Console.WriteLine("\nAfter Array.Reverse():");
        Console.WriteLine("Array reversed: " + string.Join(", ", originalArray));

        int index = Array.IndexOf(originalArray, 9);
        Console.WriteLine("\nUsing Array.IndexOf():");
        Console.WriteLine("Index of element '9': " + index);

        int[] copiedArray = new int[5];
        Array.Copy(originalArray, copiedArray, originalArray.Length);
        Console.WriteLine("\nAfter Array.Copy():");
        Console.WriteLine("Copied Array: " + string.Join(", ", copiedArray));

        Array.Clear(originalArray, 1, 3);
        Console.WriteLine("\nAfter Array.Clear():");
        Console.WriteLine("Array after clearing 3 elements starting at index 1: " + string.Join(", ", originalArray));
        Console.WriteLine();

        // problem 5
        int[] array = { 10, 20, 30, 40, 50 };

        Console.WriteLine("Using for loop:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"Element at index {i}: {array[i]}");
        }

        Console.WriteLine();

        Console.WriteLine("Using foreach loop:");
        foreach (int element in array)
        {
            Console.WriteLine($"Element: {element}");
        }

        Console.WriteLine();
        Console.WriteLine("Using while loop (reverse order):");
        int indexx = array.Length - 1;
        while (indexx >= 0)
        {
            Console.WriteLine($"Element at index {indexx}: {array[indexx]}");
            indexx--;
        }
        Console.WriteLine();

        //problem 6
        int number;
        bool isValid;

        do
        {
            Console.Write("Please enter a positive odd number: ");
            string userInput = Console.ReadLine();
            isValid = int.TryParse(userInput, out number) && number > 0 && number % 2 != 0;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Make sure it is a positive odd number.");
            }

        } while (!isValid);

        Console.WriteLine($"Thank you! You entered a valid positive odd number: {number}");
        Console.WriteLine();

        // problem 7
        int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        Console.WriteLine("The 2D array in matrix format:");

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // problem 8
        Console.Write("Enter a month number (1-12): ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int monthNumber) || monthNumber < 1 || monthNumber > 12)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 12.");
            return;
        }

        string monthNameIfElse = "";
        if (monthNumber == 1) monthNameIfElse = "January";
        else if (monthNumber == 2) monthNameIfElse = "February";
        else if (monthNumber == 3) monthNameIfElse = "March";
        else if (monthNumber == 4) monthNameIfElse = "April";
        else if (monthNumber == 5) monthNameIfElse = "May";
        else if (monthNumber == 6) monthNameIfElse = "June";
        else if (monthNumber == 7) monthNameIfElse = "July";
        else if (monthNumber == 8) monthNameIfElse = "August";
        else if (monthNumber == 9) monthNameIfElse = "September";
        else if (monthNumber == 10) monthNameIfElse = "October";
        else if (monthNumber == 11) monthNameIfElse = "November";
        else if (monthNumber == 12) monthNameIfElse = "December";

        Console.WriteLine($"(Using if-else) The month is: {monthNameIfElse}");

        string monthNameSwitch = monthNumber switch
        {
            1 => "January",
            2 => "February",
            3 => "March",
            4 => "April",
            5 => "May",
            6 => "June",
            7 => "July",
            8 => "August",
            9 => "September",
            10 => "October",
            11 => "November",
            12 => "December",
            _ => "Invalid"
        };

        Console.WriteLine($"(Using switch) The month is: {monthNameSwitch}");
        Console.WriteLine();

        // problem 9
        int[] numbers = { 10, 20, 30, 10, 40, 50, 20, 30 };

        Console.WriteLine("Original Array: " + string.Join(", ", numbers));

        Array.Sort(numbers);
        Console.WriteLine("\nSorted Array: " + string.Join(", ", numbers));

        Console.Write("\nEnter a value to search: ");
        string input1 = Console.ReadLine();

        if (int.TryParse(input1, out int searchValue))
        {
            int firstIndex = Array.IndexOf(numbers, searchValue);
            if (firstIndex != -1)
            {
                Console.WriteLine($"First occurrence of {searchValue} is at index: {firstIndex}");
            }
            else
            {
                Console.WriteLine($"Value {searchValue} not found in the array.");
            }

            int lastIndex = Array.LastIndexOf(numbers, searchValue);
            if (lastIndex != -1)
            {
                Console.WriteLine($"Last occurrence of {searchValue} is at index: {lastIndex}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
        Console.WriteLine();

        // problem 10
        int[] numb = { 10, 20, 30, 40, 50 };
        int sumForLoop = 0;
        for (int i = 0; i < numb.Length; i++)
        {
            sumForLoop += numb[i];
        }
        Console.WriteLine($"Sum of all elements using for loop: {sumForLoop}");

        int sumForeachLoop = 0;
        foreach (int n in numb)
        {
            sumForeachLoop += n;
        }
        Console.WriteLine($"Sum of all elements using foreach loop: {sumForeachLoop}");
        Console.WriteLine();





    }
    
    
}

