using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // problem 1
        Console.WriteLine("Enter a string to convert to an integer:");
        string userInput = Console.ReadLine();
        try
        {
            int parsedValue = int.Parse(userInput);
            Console.WriteLine($"int.Parse successfully converted '{userInput}' to {parsedValue}");
        }
        catch (FormatException)
        {
            Console.WriteLine("int.Parse: Input is not a valid integer format.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("int.Parse: Input is outside the range of an integer.");
        }
        try
        {
            int convertedValue = Convert.ToInt32(userInput);
            Console.WriteLine($"Convert.ToInt32 successfully converted '{userInput}' to {convertedValue}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Convert.ToInt32: Input is not a valid integer format.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Convert.ToInt32: Input is outside the range of an integer.");
        }
        Console.WriteLine("******************* problem 1 is done ****************");

        // problem 2
        Console.WriteLine("Please enter a number:");

        string userInput2 = Console.ReadLine();
        int number;

        if (int.TryParse(userInput2, out number))
        {
            Console.WriteLine($"You entered a valid integer: {number}");
        }
        else
        {
            Console.WriteLine("Error: The input is not a valid integer.");
        }
        Console.WriteLine("******************* problem 2 is done ****************");

        // problem 3
        object obj;
        obj = 42;
        Console.WriteLine($"Assigned value: {obj}, HashCode: {obj.GetHashCode()}");

        obj = "Hello, World!";
        Console.WriteLine($"Assigned value: {obj}, HashCode: {obj.GetHashCode()}");

        obj = 3.14159;
        Console.WriteLine($"Assigned value: {obj}, HashCode: {obj.GetHashCode()}");

        obj = true;
        Console.WriteLine($"Assigned value: {obj}, HashCode: {obj.GetHashCode()}");
        Console.WriteLine("******************* problem 3 is done ****************");

        // problem 4
        Person person1 = new Person();
        person1.Name = "Alice";
        Person person2 = person1;
        person2.Name = "Bob";
        Console.WriteLine("person1.Name: " + person1.Name);
        Console.WriteLine("person2.Name: " + person2.Name);
        Console.WriteLine("******************* problem 4 is done ****************");

        // problem 5
        string originalString = "Hello";
        Console.WriteLine($"Original string: {originalString}, HashCode: {originalString.GetHashCode()}");

        string modifiedString = originalString + " Hi Willy";
        Console.WriteLine($"Modified string: {modifiedString}, HashCode: {modifiedString.GetHashCode()}");
        Console.WriteLine("******************* problem 5 is done ****************");

        // problem 6
        StringBuilder sb = new StringBuilder("Hi Willy");
        Console.WriteLine($"Initial StringBuilder content: {sb}, HashCode: {sb.GetHashCode()}");

        sb.Append("! Welcome to the program.");

        Console.WriteLine($"Modified StringBuilder content: {sb}, HashCode: {sb.GetHashCode()}");
        Console.WriteLine("******************* problem 6 is done ****************");

        // problem 7
        Console.WriteLine("Enter the first integer:");
        int input1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the second integer:");
        int input2 = int.Parse(Console.ReadLine());

        int sum = input1 + input2;

        Console.WriteLine("Concatenation: Sum is " + input1 + " + " + input2 + " = " + sum);

        Console.WriteLine("Composite formatting: Sum is {0} + {1} = {2}", input1, input2, sum);

        Console.WriteLine($"String interpolation: Sum is {input1} + {input2} = {sum}");
        Console.WriteLine("******************* problem 7 is done ****************");

        // problem 8
        StringBuilder str = new StringBuilder("Hello, World!");
        Console.WriteLine($"Initial StringBuilder content: {str}");
        str.Append(" Welcome to C# programming.");
        Console.WriteLine($"After Append: {str}");

        str.Replace("World", "Universe");
        Console.WriteLine($"After Replace: {str}");

        str.Insert(7, "Beautiful ");
        Console.WriteLine($"After Insert: {str}");

        str.Remove(7, 10);
        Console.WriteLine($"After Remove: {str}");
        Console.WriteLine("******************* problem 8 is done ****************");
    }
}
class Person { 
    public string Name { get; set; }
}
