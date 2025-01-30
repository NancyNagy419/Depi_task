using System;
using System.Linq;
using System.Collections.Generic;

class Program2
{
    static void Main()
    {
        List<Product> products = ListGenerators.GetProducts();
        List<Customer> customers = ListGenerators.GetCustomers();

        Console.WriteLine("\n=== Product Names ===");
        var productNames = products.Select(p => p.Name);
        foreach (var name in productNames) Console.WriteLine(name);

        Console.WriteLine("\n=== Uppercase & Lowercase Words ===");
        string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
        var formattedWords = words.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
        foreach (var word in formattedWords) Console.WriteLine($"Upper: {word.Upper}, Lower: {word.Lower}");

        Console.WriteLine("\n=== Product Properties ===");
        var productDetails = products.Select(p => new { p.Name, Price = p.Price, p.Stock });
        foreach (var p in productDetails) Console.WriteLine($"{p.Name} - Price: {p.Price}, Stock: {p.Stock}");

        Console.WriteLine("\n=== Number Position Match ===");
        int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var positionMatch = Arr.Select((num, index) => new { Number = num, InPlace = num == index });
        foreach (var item in positionMatch) Console.WriteLine($"Number: {item.Number}, In-place? {item.InPlace}");

        Console.WriteLine("\n=== Number Pairs (a < b) ===");
        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        int[] numbersB = { 1, 3, 5, 7, 8 };
        var pairs = from a in numbersA from b in numbersB where a < b select new { A = a, B = b };
        foreach (var pair in pairs) Console.WriteLine($"{pair.A} is less than {pair.B}");

        Console.WriteLine("\n=== Orders with Total < 500.00 ===");
        var cheapOrders = customers.SelectMany(c => c.Orders).Where(o => o.Total < 500);
        foreach (var order in cheapOrders) Console.WriteLine($"Order {order.OrderID} - Total: {order.Total}");

        Console.WriteLine("\n=== Orders from 1998 or Later ===");
        var orders1998 = customers.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= 1998);
        foreach (var order in orders1998) Console.WriteLine($"Order {order.OrderID} - Date: {order.OrderDate}");
    }
}

class Product
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
}

class Customer
{
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
}

class Order
{
    public int OrderID { get; set; }
    public double Total { get; set; }
    public DateTime OrderDate { get; set; }
}

static class ListGenerators
{
    public static List<Product> GetProducts() => new List<Product>
    {
        new Product { Name = "Laptop", Stock = 5, Price = 1200 },
        new Product { Name = "Mouse", Stock = 15, Price = 25 },
        new Product { Name = "Keyboard", Stock = 10, Price = 50 },
        new Product { Name = "Monitor", Stock = 7, Price = 300 },
        new Product { Name = "Chair", Stock = 0, Price = 150 }
    };

    public static List<Customer> GetCustomers() => new List<Customer>
    {
        new Customer
        {
            Name = "Alice",
            Orders = new List<Order>
            {
                new Order { OrderID = 1, Total = 450, OrderDate = new DateTime(1999, 5, 12) },
                new Order { OrderID = 2, Total = 1200, OrderDate = new DateTime(2001, 8, 25) }
            }
        },
        new Customer
        {
            Name = "Bob",
            Orders = new List<Order>
            {
                new Order { OrderID = 3, Total = 200, OrderDate = new DateTime(1997, 3, 14) },
                new Order { OrderID = 4, Total = 550, OrderDate = new DateTime(1998, 10, 30) }
            }
        }
    };
}
