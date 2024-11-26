class Program
{
    static void Main()
    {
        // problem 1
        /*Declare two integer variables and assign values
         Calculate the sum of x and y*/
        int x = 10;
        int y = 20;
        int sum = x + y; // Add the two integers
        // Output the result to the console
        Console.WriteLine(sum);

        //problem 2
        int x1 = int.Parse("10"); // Convert the string "10" to an integer
        int y1 = 20; // Declare and initialize 'y'
        Console.WriteLine(x + y); // Use the correct case for 'Console'


        //problem 3
        string FullName = "Nancy Nagy";
        int Age = 21;
        decimal MonthlySalary = 4000.00m; // 'decimal' is used for monetary values
        bool isStudent = true;

        //problem 5
        int x2 = 15;
        int y2 = 4;
        int sum2 = x2 + y2;
        int diff = x2 - y2;
        int mul = x2 * y2;
        decimal div = x2 / y2;
        int rem = x2 % y2;
        Console.WriteLine(sum2);
        Console.WriteLine(diff);
        Console.WriteLine(mul);
        Console.WriteLine(div);
        Console.WriteLine(rem);

        //problem 6
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        if (number > 10 && number % 2 == 0)
        {
            Console.WriteLine("The number is both greater than 10 and even.");
        }
        else
        {
            Console.WriteLine("The number does not meet both conditions.");
        }

        //problem 7
        Console.Write("Enter a double value: ");
        double userInput = double.Parse(Console.ReadLine());
        double implicitCast = userInput;
        Console.WriteLine(implicitCast);
        int explicitCast = (int)userInput;
        Console.WriteLine(explicitCast);

        //problem 8
        Console.Write("Enter your age: ");
        string ageInput = Console.ReadLine();
            int age = int.Parse(ageInput);
            if (age > 0)
            {
                Console.WriteLine(age);
            }
            else
            {
                Console.WriteLine("Invalid age. Age must be greater than 0.");
            }


        
        
    }
}
