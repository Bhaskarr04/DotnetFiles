using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("E-commerce Platform Search Function");
        Console.WriteLine();
        Console.WriteLine("Understanding Asymptotic Notation and Search Algorithms");
        Console.WriteLine();

        var products = new Product[]
        {
            new Product(1, "Laptop", "Electronics", 999.99),
            new Product(2, "Smartphone", "Electronics", 699.99),
            new Product(3, "Headphones", "Electronics", 199.99),
            new Product(4, "T-Shirt", "Clothing", 29.99),
            new Product(5, "Jeans", "Clothing", 49.99),
            new Product(6, "Sneakers", "Footwear", 89.99),
            new Product(7, "Watch", "Accessories", 199.99),
            new Product(8, "Backpack", "Accessories", 59.99),
            new Product(9, "Book", "Books", 15.99),
            new Product(10, "Tablet", "Electronics", 349.99)
        };

        Console.WriteLine("Product List:");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }

        Console.WriteLine();
        Console.WriteLine("=== Linear Search Demo ===");
        Console.Write("Enter a product ID to search: ");
        if (!int.TryParse(Console.ReadLine(), out int targetId))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        var stopwatch = Stopwatch.StartNew();
        var linearResult = LinearSearch(products, targetId);
        stopwatch.Stop();

        if (linearResult != null)
            Console.WriteLine("Linear Search Result: " + linearResult);
        else
            Console.WriteLine("Product not found.");
        Console.WriteLine($"Linear search took {stopwatch.ElapsedTicks} ticks");

        Console.WriteLine();
        Console.WriteLine("=== Binary Search Demo ===");
        var sortedProducts = products.OrderBy(p => p.ProductId).ToArray();
        stopwatch.Restart();
        var binaryResult = BinarySearch(sortedProducts, targetId);
        stopwatch.Stop();

        if (binaryResult != null)
            Console.WriteLine("Binary Search Result: " + binaryResult);
        else
            Console.WriteLine("Product not found.");
        Console.WriteLine($"Binary search took {stopwatch.ElapsedTicks} ticks");

        Console.WriteLine();
        Console.WriteLine("=== Time Complexity Analysis ===");
        Console.WriteLine("Linear Search: O(n) - Must check each element in the worst case");
        Console.WriteLine("Binary Search: O(log n) - Divides search space in half each time");
        Console.WriteLine();
        Console.WriteLine("Binary search is more efficient for large datasets, but requires sorted data.");
        Console.WriteLine("Linear search works on unsorted data and is simple to implement.");
        Console.WriteLine("For small datasets, the difference in performance is negligible.");
        Console.WriteLine("For our e-commerce platform with potentially millions of products,");
        Console.WriteLine("binary search would be more suitable for ID-based searches on indexed fields.");
    }

    static Product? LinearSearch(Product[] products, int targetId)
    {
        foreach (var product in products)
        {
            if (product.ProductId == targetId)
                return product;
        }
        return null;
    }

    static Product? BinarySearch(Product[] products, int targetId)
    {
        int left = 0;
        int right = products.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (products[mid].ProductId == targetId)
                return products[mid];
            else if (products[mid].ProductId < targetId)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return null;
    }
}
