using System;

// problem 1
class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public double Price { get; set; }

    public Car()
    {
        Id = 0;
        Brand = "not yet";
        Price = 0.0;
    }
    public Car(int id)
    {
        Id = id;
        Brand = "not yet";
        Price = 0.0;
    }
    public Car(int id, string brand)
    {
        Id = id;
        Brand = brand;
        Price = 0.0;
    }
    public Car(int id, string brand, double price)
    {
        Id = id;
        Brand = brand;
        Price = price;
    }
    public void DisplayDetails()
    {
        Console.WriteLine($"Car Details: Id={Id}, Brand={Brand}, Price={Price:C}");
    }
}

// problem 2
class Calculator
{
    public int Sum(int x, int y)
    {
        return x + y;
    }
    public int Sum(int x, int y, int z)
    {
        return x + y + z;
    }
    public double Sum(double a, double b)
    {
        return a + b;
    }
}

// problem 3 & 4 & 5
class Parent
{
    public int X { get; set; }
    public int Y { get; set; }

    public Parent(int x, int y)
    {
        X = x;
        Y = y;
    }
    public virtual int Product()
    {
        return X * Y;
    }
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

class Child : Parent
{
    public int Z { get; set; }
    public Child(int x, int y, int z) : base(x, y)
    {
        Z = z;
    }
    public void DisplayDetails()
    {
        Console.WriteLine($"Child Details: X={X}, Y={Y}, Z={Z}");
    }
    public override int Product()
    {
        return base.Product() + Z;
    }
    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }
}

// problem 6 & 7
interface IShape
{
    double Area { get; }
    void Draw();
    void PrintDetails()
    {
        Console.WriteLine($"Shape with Area: {Area}");
    }
}

class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    public double Area => Width * Height;
    public void Draw()
    {
        Console.WriteLine($"Drawing a Rectangle with Width={Width} and Height={Height}");
    }
    public override string ToString()
    {
        return $"Rectangle [Width={Width}, Height={Height}, Area={Area}]";
    }
}
class Circle : IShape
{
    public double Radius { get; set; }
    public Circle(double radius)
    {
        Radius = radius;
    }
    public double Area => Math.PI * Radius * Radius;
    public void Draw()
    {
        Console.WriteLine($"Drawing a Circle with Radius={Radius}");
    }
    public override string ToString()
    {
        return $"Circle [Radius={Radius}, Area={Area:F2}]";
    }
}

// problem 8
interface IMovable
{
    void Move();
}

class Car1 : IMovable
{
    public void Move()
    {
        Console.WriteLine("The car is moving.");
    }
}

interface IReadable
{
    void Read();
}

interface IWritable
{
    void Write();
}


// problem 9
class File : IReadable, IWritable
{
    public void Read()
    {
        Console.WriteLine("Reading from file.");
    }

    public void Write()
    {
        Console.WriteLine("Writing to file.");
    }
}
 
// problem 10
abstract class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing Shape.");
    }

    public abstract double CalculateArea();
}

class Rectangle1 : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle1(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override void Draw()
    {
        Console.WriteLine("Drawing Rectangle.");
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}



class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car();
        car1.DisplayDetails();
        Car car2 = new Car(1);
        car2.DisplayDetails();
        Car car3 = new Car(2, "Toyota");
        car3.DisplayDetails();
        Car car4 = new Car(3, "BMW", 70000.0);
        car4.DisplayDetails();

        Calculator calculator = new Calculator();
        Console.WriteLine("Sum of 5 and 3: " + calculator.Sum(8, 3));
        Console.WriteLine("Sum of 5, 3, and 2: " + calculator.Sum(8, 3, 2));
        Console.WriteLine("Sum of 5.5 and 3.3: " + calculator.Sum(5.5, 3.3));

        Child child = new Child(10, 20, 30);
        child.DisplayDetails();

        Parent parent = new Parent(10, 20);
        Console.WriteLine("Parent Product: " + parent.Product());
        Console.WriteLine("Child Product (override): " + child.Product());
        Parent childAsParent = child;
        Console.WriteLine("Child Product (via Parent reference): " + childAsParent.Product());

        Console.WriteLine("Parent ToString: " + parent);
        Console.WriteLine("Child ToString: " + child);

        Rectangle rectangle = new Rectangle(10, 20);
        rectangle.Draw();
        Console.WriteLine(rectangle);

        Circle circle = new Circle(15);
        circle.Draw();
        ((IShape)circle).PrintDetails();
        Console.WriteLine(circle);

        IMovable movableCar = new Car1();
        movableCar.Move();

        File file = new File();
        IReadable readableFile = file;
        IWritable writableFile = file;

        readableFile.Read();
        writableFile.Write();

        Shape shape = new Rectangle1(5, 10);
        shape.Draw();
        Console.WriteLine("Area: " + shape.CalculateArea());
    }
}

