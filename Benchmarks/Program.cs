using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarks
{
    static class Program
    {
        static void Main(string[] args)
        {
            var dictSize = 1000000;

            Console.WriteLine("Dictionary, single threaded:");
            var dict = new Dictionary<int, int>();
            SingleThreadBenchmark.TimeDict(dict, dictSize);

        }
    }
}
