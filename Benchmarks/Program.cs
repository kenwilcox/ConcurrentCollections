using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Benchmarks
{
    static class Program
    {
        static void Main()
        {
            const int dictSize = 1000000;

            Console.WriteLine("Dictionary, single thread:");
            var dict = new Dictionary<int, int>();
            SingleThreadBenchmark.TimeDict(dict, dictSize);

            Console.WriteLine("\r\nConcurrentDictionary, single thread:");
            var dict2 = new ConcurrentDictionary<int, int>();
            SingleThreadBenchmark.TimeDict(dict2, dictSize);

            Console.WriteLine("\r\nConcurrentDictionary, multiple threads:");
            dict2 = new ConcurrentDictionary<int, int>();
            ParallelBenchmark.TimeDictParallel(dict2, dictSize);
        }
    }
}
