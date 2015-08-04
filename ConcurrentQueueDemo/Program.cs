using System;
using System.Collections.Concurrent;

namespace ConcurrentQueueDemo
{
    public static class Program
    {
        static void Main()
        {
            var shirts = new ConcurrentStack<string>();
            shirts.Push("Pluralsight");
            shirts.Push("WordPress");
            shirts.Push("Code School");

            Console.WriteLine("After enqueuing, count = " + shirts.Count);

            string item1;
            var success = shirts.TryPop(out item1);
            if (success)
                Console.WriteLine("\r\nRemoving " + item1);
            else
                Console.WriteLine("Queue was Empty");

            string item2;
            success = shirts.TryPeek(out item2);
            if (success)
                Console.WriteLine("Peeking   " + item2);
            else
                Console.WriteLine("Queue was empty");

            Console.WriteLine("\r\nEnumerating:");
            foreach (var item in shirts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\r\nAfter enumerating, count = " + shirts.Count);
        }
    }
}
