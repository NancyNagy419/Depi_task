using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Product> products = ListGenerators.GetProducts();
        List<Customer> customers = ListGenerators.GetCustomers();
        List<Category> categories = ListGenerators.GetCategories();
        string[] dictionaryWords = ListGenerators.GetDictionaryWords();

        // === Restriction Operators ===
        Console.WriteLine("=== Restriction Operators ===");

        var outOfStockProducts = products.Where(p => p.Stock == 0);
        Console.WriteLine("\nOut of Stock Products:");
        foreach (var p in outOfStockProducts) Console.WriteLine(p.Name);

        var expensiveInStockProducts = products.Where(p => p.Stock > 0 && p.Price > 3.00);
        Console.WriteLine("\nIn-Stock Products with Price > 3.00:");
        foreach (var p in expensiveInStockProducts) Console.WriteLine(p.Name);

        string[] digitsArr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        var shortNamedDigits = digitsArr.Where((name, index) => name.Length < index);
        Console.WriteLine("\nDigits with Shorter Names:");
        foreach (var d in shortNamedDigits) Console.WriteLine(d);

        // === Element Operators ===
        Console.WriteLine("\n=== Element Operators ===");

        var firstOutOfStock = products.FirstOrDefault(p => p.Stock == 0);
        Console.WriteLine("\nFirst Out of Stock Product: " + (firstOutOfStock != null ? firstOutOfStock.Name : "None"));

        var expensiveProduct = products.FirstOrDefault(p => p.Price > 1000);
        Console.WriteLine("\nFirst Expensive Product (Price > 1000): " + (expensiveProduct != null ? expensiveProduct.Name : "None"));

        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var secondGreaterThanFive = numbers.Where(n => n > 5).Skip(1).FirstOrDefault();
        Console.WriteLine("\nSecond Number Greater than 5: " + secondGreaterThanFive);

        // === Aggregate Operators ===
        Console.WriteLine("\n=== Aggregate Operators ===");

        int oddCount = numbers.Count(n => n % 2 != 0);
        Console.WriteLine("\nNumber of Odd Numbers: " + oddCount);

        var customerOrders = customers.Select(c => new { c.Name, OrderCount = c.Orders.Count });
        Console.WriteLine("\nCustomers and Order Counts:");
        foreach (var c in customerOrders) Console.WriteLine($"{c.Name}: {c.OrderCount} orders");

        var categoryProducts = categories.Select(c => new { c.Name, ProductCount = c.Products.Count });
        Console.WriteLine("\nCategories and Product Counts:");
        foreach (var c in categoryProducts) Console.WriteLine($"{c.Name}: {c.ProductCount} products");

        int totalSum = numbers.Sum();
        Console.WriteLine("\nTotal Sum of Numbers: " + totalSum);

        int totalChars = dictionaryWords.Sum(word => word.Length);
        Console.WriteLine("\nTotal Characters in Dictionary: " + totalChars);

        var totalStockPerCategory = categories.Select(c => new { c.Name, TotalStock = c.Products.Sum(p => p.Stock) });
        Console.WriteLine("\nTotal Stock per Category:");
        foreach (var c in totalStockPerCategory) Console.WriteLine($"{c.Name}: {c.TotalStock} units");

        int shortestWordLength = dictionaryWords.Min(word => word.Length);
        Console.WriteLine("\nShortest Word Length: " + shortestWordLength);

        // === Ordering Operators ===
        Console.WriteLine("\n=== Ordering Operators ===");

        var sortedProductsByName = products.OrderBy(p => p.Name);
        Console.WriteLine("\nProducts Sorted by Name:");
        foreach (var p in sortedProductsByName) Console.WriteLine(p.Name);

        string[] words = { "aPPLE", "BaNaNa", "bRaNch", "BlueBeRrY", "CloVer", "cheRry" };
        var caseInsensitiveSortedWords = words.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine("\nCase-Insensitive Sorted Words:");
        foreach (var w in caseInsensitiveSortedWords) Console.WriteLine(w);

        var sortedByStockDesc = products.OrderByDescending(p => p.Stock);
        Console.WriteLine("\nProducts Sorted by Stock (Descending):");
        foreach (var p in sortedByStockDesc) Console.WriteLine(p.Name);

        var sortedDigitsByLengthThenAlphabetical = digitsArr.OrderBy(d => d.Length).ThenBy(d => d);
        Console.WriteLine("\nDigits Sorted by Length and Alphabetically:");
        foreach (var d in sortedDigitsByLengthThenAlphabetical) Console.WriteLine(d);

        var sortedWordsByLengthThenInsensitive = words.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine("\nWords Sorted by Length and Case-Insensitive:");
        foreach (var w in sortedWordsByLengthThenInsensitive) Console.WriteLine(w);

        var sortedByCategoryThenPriceDesc = products.OrderBy(p => p.Category).ThenByDescending(p => p.Price);
        Console.WriteLine("\nProducts Sorted by Category and Price (Descending):");
        foreach (var p in sortedByCategoryThenPriceDesc) Console.WriteLine($"{p.Category}: {p.Name} - ${p.Price}");

        var sortedWordsByLengthThenInsensitiveDesc = words.OrderBy(w => w.Length).ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine("\nWords Sorted by Length and Case-Insensitive Descending:");
        foreach (var w in sortedWordsByLengthThenInsensitiveDesc) Console.WriteLine(w);

        var reversedDigitsWithIAsSecond = digitsArr.Where(d => d.Length > 1 && d[1] == 'i').Reverse();
        Console.WriteLine("\nDigits with 'i' as Second Letter (Reversed Order):");
        foreach (var d in reversedDigitsWithIAsSecond) Console.WriteLine(d);
    }
}

// Sample Classes
class Product
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}

class Customer
{
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
}

class Order
{
    public int OrderID { get; set; }
}

class Category
{
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}

// Mock Data Generator
static class ListGenerators
{
    public static List<Product> GetProducts() => new List<Product>
    {
        new Product { Name = "Laptop", Stock = 5, Price = 1200, Category = "Electronics" },
        new Product { Name = "Mouse", Stock = 15, Price = 25, Category = "Accessories" },
        new Product { Name = "Keyboard", Stock = 10, Price = 50, Category = "Accessories" },
        new Product { Name = "Monitor", Stock = 7, Price = 300, Category = "Electronics" },
        new Product { Name = "Chair", Stock = 0, Price = 150, Category = "Furniture" }
    };

    public static List<Customer> GetCustomers() => new List<Customer>
    {
        new Customer { Name = "Alice", Orders = new List<Order> { new Order { OrderID = 1 }, new Order { OrderID = 2 } } },
        new Customer { Name = "Bob", Orders = new List<Order> { new Order { OrderID = 3 } } }
    };

    public static List<Category> GetCategories() => new List<Category>
    {
        new Category { Name = "Electronics", Products = GetProducts().Where(p => p.Category == "Electronics").ToList() },
        new Category { Name = "Accessories", Products = GetProducts().Where(p => p.Category == "Accessories").ToList() }
    };

    public static string[] GetDictionaryWords() => new string[] { "apple", "banana", "cherry", "date", "elderberry" };
}
