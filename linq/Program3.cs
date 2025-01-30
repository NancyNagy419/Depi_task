using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

class Program3
{
    static void Main()
    {
        // Sample Data
        List<Product> products = ListGenerators.GetProducts();
        List<Customer> customers = ListGenerators.GetCustomers();
        string[] dictionaryWords = File.ReadAllLines("dictionary_english.txt");
        int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        int oddCount = Arr.Count(n => n % 2 != 0);
        Console.WriteLine($"Count of odd numbers: {oddCount}");

        var customerOrders = customers.Select(c => new { c.Name, OrderCount = c.Orders.Count });
        Console.WriteLine("\nCustomer Order Counts:");
        foreach (var item in customerOrders) Console.WriteLine($"{item.Name}: {item.OrderCount} orders");

        var categoryCounts = products.GroupBy(p => p.Category)
                                     .Select(g => new { Category = g.Key, ProductCount = g.Count() });
        Console.WriteLine("\nProduct Category Counts:");
        foreach (var item in categoryCounts) Console.WriteLine($"{item.Category}: {item.ProductCount} products");

        int totalSum = Arr.Sum();
        Console.WriteLine($"\nSum of array elements: {totalSum}");

        int totalChars = dictionaryWords.Sum(w => w.Length);
        Console.WriteLine($"\nTotal characters in dictionary: {totalChars}");

        var totalStockByCategory = products.GroupBy(p => p.Category)
                                           .Select(g => new { Category = g.Key, TotalStock = g.Sum(p => p.Stock) });
        Console.WriteLine("\nTotal Units in Stock by Category:");
        foreach (var item in totalStockByCategory) Console.WriteLine($"{item.Category}: {item.TotalStock} units");

        int shortestLength = dictionaryWords.Min(w => w.Length);
        Console.WriteLine($"\nShortest word length in dictionary: {shortestLength}");

        var cheapestByCategory = products.GroupBy(p => p.Category)
                                         .Select(g => new { Category = g.Key, MinPrice = g.Min(p => p.Price) });
        Console.WriteLine("\nCheapest Price by Category:");
        foreach (var item in cheapestByCategory) Console.WriteLine($"{item.Category}: ${item.MinPrice}");

        var cheapestProducts = products.GroupBy(p => p.Category)
                                       .Select(g => new { Category = g.Key, Product = g.OrderBy(p => p.Price).First() });
        Console.WriteLine("\nCheapest Products in Each Category:");
        foreach (var item in cheapestProducts) Console.WriteLine($"{item.Category}: {item.Product.Name} - ${item.Product.Price}");

        int longestLength = dictionaryWords.Max(w => w.Length);
        Console.WriteLine($"\nLongest word length in dictionary: {longestLength}");

        var expensiveByCategory = products.GroupBy(p => p.Category)
                                          .Select(g => new { Category = g.Key, MaxPrice = g.Max(p => p.Price) });
        Console.WriteLine("\nMost Expensive Price by Category:");
        foreach (var item in expensiveByCategory) Console.WriteLine($"{item.Category}: ${item.MaxPrice}");

        var expensiveProducts = products.GroupBy(p => p.Category)
                                        .Select(g => new { Category = g.Key, Product = g.OrderByDescending(p => p.Price).First() });
        Console.WriteLine("\nMost Expensive Products in Each Category:");
        foreach (var item in expensiveProducts) Console.WriteLine($"{item.Category}: {item.Product.Name} - ${item.Product.Price}");

        double avgWordLength = dictionaryWords.Average(w => w.Length);
        Console.WriteLine($"\nAverage word length in dictionary: {avgWordLength:F2}");

        var avgPriceByCategory = products.GroupBy(p => p.Category)
                                         .Select(g => new { Category = g.Key, AvgPrice = g.Average(p => p.Price) });
        Console.WriteLine("\nAverage Price by Category:");
        foreach (var item in avgPriceByCategory) Console.WriteLine($"{item.Category}: ${item.AvgPrice:F2}");
    }
}

class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
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
        new Product { Name = "Laptop", Category = "Electronics", Stock = 5, Price = 1200 },
        new Product { Name = "Mouse", Category = "Electronics", Stock = 15, Price = 25 },
        new Product { Name = "Keyboard", Category = "Electronics", Stock = 10, Price = 50 },
        new Product { Name = "Monitor", Category = "Electronics", Stock = 7, Price = 300 },
        new Product { Name = "Chair", Category = "Furniture", Stock = 0, Price = 150 },
        new Product { Name = "Desk", Category = "Furniture", Stock = 2, Price = 450 },
        new Product { Name = "Sofa", Category = "Furniture", Stock = 3, Price = 800 }
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

