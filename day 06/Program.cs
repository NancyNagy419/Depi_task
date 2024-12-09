using System;

namespace StructAndClassExamples
{
    // Problem 1: Define a struct Point with X and Y attributes and constructors
    public struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point() : this(0, 0) { }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(int x) : this(x, 0) { }

        public override string ToString()
        {
            return $"Point: ({X}, {Y})";
        }
    }

    // Problem 2: Create a class TypeA with attributes F, G, and H
    public class TypeA
    {
        private int F;
        internal int G;
        public int H;

        public TypeA(int f, int g, int h)
        {
            F = f;
            G = g;
            H = h;
        }

        public int GetF()
        {
            return F;
        }
    }

    // Problem 3: Define a struct Employee with private attributes
    public struct Employee
    {
        private int empId;
        private string name;
        private decimal salary;

        public Employee(int empId, string name, decimal salary)
        {
            this.empId = empId;
            this.name = name;
            this.salary = salary;
        }

        public string GetName() => name;

        public void SetName(string newName) => name = newName;

        public decimal Salary
        {
            get => salary;
            set => salary = value;
        }

        public int EmpId => empId;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Problem 4: Testing the Point struct
            Point defaultPoint = new Point();
            Console.WriteLine(defaultPoint);

            Point paramPoint = new Point(5, 10);
            Console.WriteLine(paramPoint);

            Point singleParamPoint = new Point(7);
            Console.WriteLine(singleParamPoint);

            // Problem 5: Testing the TypeA class
            TypeA typeA = new TypeA(10, 20, 30);
            Console.WriteLine($"Public Attribute H: {typeA.H}");
            Console.WriteLine($"Internal Attribute G: {typeA.G}");
            Console.WriteLine($"Private Attribute F: {typeA.GetF()}");

            // Problem 6: Testing the Employee struct
            Employee employee = new Employee(101, "John Doe", 50000);
            Console.WriteLine($"Employee ID: {employee.EmpId}");
            Console.WriteLine($"Employee Name: {employee.GetName()}");
            Console.WriteLine($"Employee Salary: {employee.Salary}");

            // Updating employee details
            employee.SetName("Jane Smith");
            employee.Salary = 55000;
            Console.WriteLine($"Updated Employee Name: {employee.GetName()}");
            Console.WriteLine($"Updated Employee Salary: {employee.Salary}");

            
            Point pointA = new Point(3, 4);
            ModifyPoint(pointA);
            Console.WriteLine($"Point after ModifyPoint: {pointA}");

            TypeA typeAReference = new TypeA(1, 2, 3);
            ModifyTypeA(typeAReference);
            Console.WriteLine($"TypeA after ModifyTypeA: {typeAReference.H}");
        }

        static void ModifyPoint(Point point)
        {
            Console.WriteLine("Inside ModifyPoint");
            Console.WriteLine($"Received Point: {point}");
        }

        static void ModifyTypeA(TypeA typeA)
        {
            Console.WriteLine("Inside ModifyTypeA");
            Console.WriteLine($"Received TypeA H: {typeA.H}");
        }
    }
}

