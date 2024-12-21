using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Problem 1: Enum - Weekdays
        Console.WriteLine("Problem 1:");
        foreach (var day in Enum.GetValues(typeof(Weekdays)))
        {
            Console.WriteLine($"{day} = {(int)day}");
        }
        Console.WriteLine();

        // Problem 2: Grades Enum with short type
        Console.WriteLine("Problem 2:");
        foreach (var grade in Enum.GetValues(typeof(Grades)))
        {
            Console.WriteLine($"{grade} = {(short)grade}");
        }
        Console.WriteLine();

        // Problem 3: Adding Department to Person
        Console.WriteLine("Problem 3:");
        Person person1 = new Person { Name = "Alice", Department = "HR" };
        Person person2 = new Person { Name = "Bob", Department = "IT" };
        Console.WriteLine(person1);
        Console.WriteLine(person2);
        Console.WriteLine();

        // Problem 4: Sealed Salary in Child class
        Console.WriteLine("Problem 4:");
        Child child = new Child { Salary = 5000 };
        child.DisplaySalary();
        Console.WriteLine();

        // Problem 5: Static Method for Perimeter in Utility
        Console.WriteLine("Problem 5:");
        double perimeter = Utility.CalculateRectanglePerimeter(5.0, 3.0);
        Console.WriteLine($"Perimeter of the rectangle: {perimeter}");
        Console.WriteLine();

        // Problem 6: Operator Overloading in ComplexNumber
        Console.WriteLine("Problem 6:");
        ComplexNumber num1 = new ComplexNumber(3, 4);
        ComplexNumber num2 = new ComplexNumber(1, 2);
        ComplexNumber result = num1 * num2;
        Console.WriteLine($"Multiplication Result: {result}");
        Console.WriteLine();

        // Problem 7: Gender Enum with byte type
        Console.WriteLine("Problem 7:");
        Console.WriteLine($"Memory size of Gender enum: {sizeof(Gender)} bytes");
        Console.WriteLine();

        // Problem 8: Temperature Conversion
        Console.WriteLine("Problem 8:");
        double celsius = Utility.ConvertTemperature(98.6, "FahrenheitToCelsius");
        double fahrenheit = Utility.ConvertTemperature(37, "CelsiusToFahrenheit");
        Console.WriteLine($"Celsius: {celsius}, Fahrenheit: {fahrenheit}");
        Console.WriteLine();

        // Problem 9: Parsing Enum Values
        Console.WriteLine("Problem 9:");
        string input = "A";
        if (Enum.TryParse(input, out Grades parsedGrade))
        {
            Console.WriteLine($"Parsed Grade: {parsedGrade}");
        }
        else
        {
            Console.WriteLine("Invalid input for Grades enum.");
        }
        Console.WriteLine();

        // Problem 10: Generic Helper Methods
        Console.WriteLine("Problem 10:");
        Console.WriteLine();
        
        /////////// part 2 //////////

        // Problem 1: Reversing an Array
        Console.WriteLine("Generic Problem 1: Reversing an Array");
        int[] intArray = { 1, 2, 3, 4, 5 };
        string[] stringArray = { "A", "B", "C", "D" };
        var reversedIntArray = ArrayHelper.ReverseArray(intArray);
        var reversedStringArray = ArrayHelper.ReverseArray(stringArray);
        Console.WriteLine($"Reversed Int Array: {string.Join(", ", reversedIntArray)}");
        Console.WriteLine($"Reversed String Array: {string.Join(", ", reversedStringArray)}");
        Console.WriteLine();

        // Problem 2: Generic Stack
        Console.WriteLine("Generic Problem 2: Generic Stack");
        GenericStack<int> stack = new GenericStack<int>();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        Console.WriteLine($"Popped: {stack.Pop()}");
        Console.WriteLine($"Peek: {stack.Peek()}");
        Console.WriteLine();

        // Problem 3: Swapping Elements
        Console.WriteLine("Generic Problem 3: Swapping Elements");
        int[] swapArray = { 10, 20, 30, 40 };
        ArrayHelper.SwapElements(swapArray, 1, 3);
        Console.WriteLine($"Array after swapping: {string.Join(", ", swapArray)}");
        Console.WriteLine();

        // Problem 4: Finding Maximum Element
        Console.WriteLine("Generic Problem 4: Finding Maximum Element");
        int[] numbers = { 5, 1, 9, 3, 7 };
        string[] names = { "Alice", "Bob", "Charlie" };
        Console.WriteLine($"Max in numbers: {ArrayHelper.FindMax(numbers)}");
        Console.WriteLine($"Max in names: {ArrayHelper.FindMax(names)}");
    }
}

// Weekdays Enum
enum Weekdays
{
    Monday = 1,
    Tuesday,
    Wednesday,
    Thursday,
    Friday
}

// Grades Enum
enum Grades : short
{
    A = 4,
    B = 3,
    C = 2,
    D = 1,
    F = -1
}

// Gender Enum
enum Gender : byte
{
    Male = 1,
    Female = 2
}

// Person Class
class Person
{
    public string Name { get; set; }
    public string Department { get; set; }

    public override string ToString()
    {
        return $"{Name} works in {Department} department.";
    }
}

// Child Class
class Child
{
    public int Salary { get; set; }
    public void DisplaySalary()
    {
        Console.WriteLine($"Child's Salary: {Salary}");
    }
}

// Utility Class
static class Utility
{
    public static double CalculateRectanglePerimeter(double length, double width)
    {
        return 2 * (length + width);
    }

    public static double ConvertTemperature(double value, string conversionType)
    {
        return conversionType switch
        {
            "FahrenheitToCelsius" => (value - 32) * 5 / 9,
            "CelsiusToFahrenheit" => (value * 9 / 5) + 32,
            _ => throw new ArgumentException("Invalid conversion type")
        };
    }
}

// ComplexNumber Class
class ComplexNumber
{
    public double Real { get; }
    public double Imaginary { get; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(
            (a.Real * b.Real) - (a.Imaginary * b.Imaginary),
            (a.Real * b.Imaginary) + (a.Imaginary * b.Real)
        );
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}

// Generic Helper Methods and Classes

public static class ArrayHelper
{
    public static T[] ReverseArray<T>(T[] array)
    {
        T[] reversed = new T[array.Length];
        for (int i = 0, j = array.Length - 1; i < array.Length; i++, j--)
        {
            reversed[i] = array[j];
        }
        return reversed;
    }

    public static void SwapElements<T>(T[] array, int index1, int index2)
    {
        T temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }

    public static T FindMax<T>(T[] array) where T : IComparable<T>
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Array cannot be null or empty.");

        T max = array[0];
        foreach (var item in array)
        {
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }
        return max;
    }
}

public class GenericStack<T>
{
    private List<T> _elements = new List<T>();

    public void Push(T item)
    {
        _elements.Add(item);
    }

    public T Pop()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("Stack is empty.");
        T item = _elements[_elements.Count - 1];
        _elements.RemoveAt(_elements.Count - 1);
        return item;
    }

    public T Peek()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("Stack is empty.");
        return _elements[_elements.Count - 1];
    }

    public int Count => _elements.Count;
}
