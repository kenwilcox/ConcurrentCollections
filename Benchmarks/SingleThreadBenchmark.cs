using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarks
{
    class SingleThreadBenchmark
    {
        static void PopulateDict(IDictionary<int, int> dict, int dictSize)
        {
            for (var i = 0; i < dictSize; i++)
            {
                dict.Add(i, 0);
            }

            for (var i = 0; i < dictSize; i++)
            {
                dict[i] += 1;
                Worker.DoSomethingTimeConsuming();
            }
        }

        static int GetTotalValue(IDictionary<int, int> dict)
        {
            var total = 0;
            foreach (var item in dict)
            {
                total += dict[item.Value];
                Worker.DoSomethingTimeConsuming();
            }
            return total;
        }

        public static void TimeDict(IDictionary<int, int> dict, int dictSize)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            PopulateDict(dict, dictSize);
            stopwatch.Stop();
            Console.WriteLine("Time taken to build dictionary (ms):     {0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            var total = GetTotalValue(dict);
            stopwatch.Stop();
            Console.WriteLine("Time taken to enumerate dictionary (ms): {0}", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Total is " + total);
            if (total != dictSize)
                Console.WriteLine("ERROR IN TOTAL!");
        }
    }
}
