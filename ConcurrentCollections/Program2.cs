using System;
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
            var stock = new Dictionary<string, int>()
            {
                {"jDays", 4},
                {"technologyhour", 3}
            };

            Console.WriteLine("No. of shirts in stock = {0}", stock.Count);

            stock.Add("pluralsight", 6);
            stock["buddhistgeeks"] = 5;

            stock["pluralsight"] += 1; // we just bought one
            Console.WriteLine("\r\nstock[pluralsight] = {0}", stock["pluralsight"]);

            stock.Remove("jDays");

            Console.WriteLine("\r\nEnumerating:");
            foreach (var keyValuePair in stock)
            {
                Console.WriteLine("{0}: {1}", keyValuePair.Key, keyValuePair.Value);
            }
        }
    }
}
