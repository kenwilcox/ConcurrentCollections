using System;
using System.Collections.Concurrent;

namespace EnumerateDictionary
{
    public static class Program
    {
        static void Main()
        {
            var stock = new ConcurrentDictionary<string, int>();
            stock.TryAdd("jDays", 0);
            stock.TryAdd("Code School", 0);
            stock.TryAdd("Buddhist Geeks", 0);

            foreach (var shirt in stock)
            {
                var ret = stock.AddOrUpdate("jDays", 0, (key, value) => value + 1);
                Console.WriteLine("Return: " + ret);
                Console.WriteLine(shirt.Key + ": " + shirt.Value);
            }

            Console.WriteLine("jDays: " + stock["jDays"]);
        }
    }
}
