using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Financial Forecasting Tool");
        Console.WriteLine("===========================");
        Console.WriteLine();

        double initialValue = 10000.0;
        double growthRate = 0.05;
        int years = 10;
        double monthlyInvestment = 100.0;

        Console.WriteLine($"Initial Investment: ${initialValue:F2}");
        Console.WriteLine($"Annual Growth Rate: {growthRate * 100:F2}%");
        Console.WriteLine($"Forecast Period: {years} years");
        Console.WriteLine();

        Console.WriteLine("Calculating future values using different methods...");
        Console.WriteLine();

        // Simple recursive
        Stopwatch sw = Stopwatch.StartNew();
        double value1 = ForecastRecursive(initialValue, growthRate, years);
        sw.Stop();
        Console.WriteLine("Simple Recursive Method:");
        Console.WriteLine($"Future Value after {years} years: ${value1:F2}");
        Console.WriteLine($"Calculation time: {sw.ElapsedTicks} ticks");
        Console.WriteLine();

        // Memoized recursive
        sw.Restart();
        double[] memo = new double[years + 1];
        double value2 = ForecastMemoized(initialValue, growthRate, years, memo);
        sw.Stop();
        Console.WriteLine("Optimized Recursive Method (with memoization):");
        Console.WriteLine($"Future Value after {years} years: ${value2:F2}");
        Console.WriteLine($"Calculation time: {sw.ElapsedTicks} ticks");
        Console.WriteLine();

        // Iterative
        sw.Restart();
        double value3 = ForecastIterative(initialValue, growthRate, years);
        sw.Stop();
        Console.WriteLine("Iterative Method:");
        Console.WriteLine($"Future Value after {years} years: ${value3:F2}");
        Console.WriteLine($"Calculation time: {sw.ElapsedTicks} ticks");
        Console.WriteLine();

        // Variable growth rate
        double[] rates = {0.05,0.045,0.048,0.052,0.049,0.051,0.047,0.053,0.05,0.05};
        double varGrowth = VariableGrowth(initialValue, rates);
        Console.WriteLine("Variable Growth Rate Method:");
        Console.WriteLine($"Future Value with variable growth rates: ${varGrowth:F2}");
        Console.WriteLine();

        // With Monthly Investments
        Console.WriteLine($"Method with Monthly Investments (${monthlyInvestment:F2}/month):");

        double compounded = initialValue;
        for (int i = 0; i < years; i++)
        {
            compounded *= (1 + growthRate);
            compounded += monthlyInvestment * 12;
        }

        Console.WriteLine($"Future Value after {years} years: ${compounded:F2}");
        Console.WriteLine();

        Console.WriteLine("=== Time Complexity Analysis ===");
        Console.WriteLine("Simple Recursive Method: O(n) - Linear time complexity");
        Console.WriteLine(" - Each call depends on the result of the previous call");
        Console.WriteLine(" - Creates a call stack of depth n (periods)");
        Console.WriteLine(" - Risk of stack overflow for large n");
        Console.WriteLine();
        Console.WriteLine("Memoized Recursive Method: O(n) - Linear time complexity with space optimization");
        Console.WriteLine(" - Avoids redundant calculations by storing results");
        Console.WriteLine(" - Uses additional O(n) memory for memoization table");
        Console.WriteLine(" - Still creates a call stack but avoids recalculation");
        Console.WriteLine();
        Console.WriteLine("Iterative Method: O(n) - Linear time complexity");
        Console.WriteLine(" - Same computational complexity as recursive methods");
        Console.WriteLine(" - Constant space complexity (no call stack or memo table)");
        Console.WriteLine(" - Generally more efficient in practice");
        Console.WriteLine();
        Console.WriteLine("Recommendation for optimizing recursive solutions:");
        Console.WriteLine("1. Use memoization to avoid redundant calculations");
        Console.WriteLine("2. Consider tail recursion when applicable");
        Console.WriteLine("3. For simple growth formulas, iterative solutions may be more efficient");
        Console.WriteLine("4. For complex models with variable inputs, recursion offers more flexibility");
    }

    static double ForecastRecursive(double value, double rate, int years)
    {
        if (years == 0) return value;
        return ForecastRecursive(value * (1 + rate), rate, years - 1);
    }

    static double ForecastMemoized(double value, double rate, int years, double[] memo)
    {
        if (years == 0) return value;
        if (memo[years] != 0) return memo[years];
        memo[years] = ForecastMemoized(value * (1 + rate), rate, years - 1, memo);
        return memo[years];
    }

    static double ForecastIterative(double value, double rate, int years)
    {
        for (int i = 0; i < years; i++)
        {
            value *= (1 + rate);
        }
        return value;
    }

    static double VariableGrowth(double value, double[] rates)
    {
        foreach (var r in rates)
        {
            value *= (1 + r);
        }
        return value;
    }
}
