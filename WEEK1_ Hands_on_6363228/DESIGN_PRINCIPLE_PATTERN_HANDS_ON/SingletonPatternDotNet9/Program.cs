using System;

class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        logger1.Log("This is the first log message.");

        Logger logger2 = Logger.GetInstance();
        logger2.Log("This is the second log message.");

        if (ReferenceEquals(logger1, logger2))
        {
            Console.WriteLine("Both logger1 and logger2 refer to the same instance.");
        }
        else
        {
            Console.WriteLine("Different instances exist. Singleton failed.");
        }
    }
}
