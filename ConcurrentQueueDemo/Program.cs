using System;
using System.Collections.Concurrent;

namespace ConcurrentQueueDemo
{
    public static class Program
    {
        static void Main()
        {
            IProducerConsumerCollection<string> shirts = new ConcurrentBag<string>();
            shirts.TryAdd("Pluralsight");
            shirts.TryAdd("WordPress");
            shirts.TryAdd("Code School");

            Console.WriteLine("After enqueuing, count = " + shirts.Count);

            string item1;
            var success = shirts.TryTake(out item1);
            if (success)
                Console.WriteLine("\r\nRemoving " + item1);
            else
                Console.WriteLine("Queue was Empty");

            Console.WriteLine("\r\nEnumerating:");
            foreach (var item in shirts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\r\nAfter enumerating, count = " + shirts.Count);
        }
    }
}
