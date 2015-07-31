using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentCollections
{
    public static class Program2
    {
        public static void Main(string[] args)
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

            success = stock.TryUpdate("pluralsight", 7, 6);
            Console.WriteLine("pluralsight = {0}, did update work? {1}", stock["pluralsight"], success);
            success = stock.TryUpdate("pluralsight", 7, 6);
            Console.WriteLine("pluralsight = {0}, did update work? {1}", stock["pluralsight"], success);

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
