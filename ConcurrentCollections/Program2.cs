using System;
using System.Collections.Concurrent;

namespace ConcurrentCollections
{
    public static class Program2
    {
        public static void Main()
        {
            var stock = new ConcurrentDictionary<string, int>();
            stock.TryAdd("jDays", 4);
            stock.TryAdd("technologyhour", 3);

            Console.WriteLine("No. of shirts in stock = {0}", stock.Count);

            var success = stock.TryAdd("pluralsight", 6);
            Console.WriteLine("Added succeeded? " + success);
            success = stock.TryAdd("pluralsight", 6);
            Console.WriteLine("Added succeeded? " + success);

            stock["buddhistgeeks"] = 5;

            //stock["pluralsight"]++; <-- not thread safe two instructions
            var psStock = stock.AddOrUpdate("pluralsight", 1, (key, oldValue) => oldValue + 1);
            Console.WriteLine("pluralsight new value = {0}", psStock);

            int jDaysValue;
            success= stock.TryRemove("jDays", out jDaysValue);
            if (success) Console.WriteLine("Value removed was: " + jDaysValue);

            Console.WriteLine("\r\nEnumerating:");
            foreach (var keyValuePair in stock)
            {
                Console.WriteLine("{0}: {1}", keyValuePair.Key, keyValuePair.Value);
            }
        }
    }
}
