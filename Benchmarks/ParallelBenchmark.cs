﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Benchmarks
{
    class ParallelBenchmark
    {
        static void PopulateDictParallel(ConcurrentDictionary<int, int> dict, int dictSize)
        {
            Parallel.For(0, dictSize, (i) => dict.TryAdd(i, 0));
            Parallel.For(0, dictSize, (i) =>
            {
                bool done = dict.TryUpdate(i, 1, 0);
                if (!done) throw new Exception("Error updating. Old value was " + dict[i]);
                Worker.DoSomethingTimeConsuming();
            });
        }

        static int GetTotalValueParallel(ConcurrentDictionary<int, int> dict)
        {
            int expectedTotal = dict.Count;

            int total = 0;
            Parallel.ForEach(dict, keyValPair =>
            {
                Interlocked.Add(ref total, keyValPair.Value);
                Worker.DoSomethingTimeConsuming();
            });
            return total;
        }

        public static void TimeDictParallel(ConcurrentDictionary<int, int> dict, int dictSize)
        {
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            PopulateDictParallel(dict, dictSize);
            stopwatch.Stop();
            Console.WriteLine("Time taken to build dictionary (ms):     {0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            var total = GetTotalValueParallel(dict);
            stopwatch.Stop();
            Console.WriteLine("Time taken to enumerate dictionary (ms): {0}", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Total is " + total);
            if (total != dictSize)
                Console.WriteLine("ERROR IN TOTAL!");
        }
    }
}
