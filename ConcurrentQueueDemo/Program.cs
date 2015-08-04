using System;
using System.Collections.Generic;

namespace ConcurrentQueueDemo
{
    public static class Program
    {
        static void Main()
        {
            var shirts = new Queue<string>();
            shirts.Enqueue("Pluralsight");
            shirts.Enqueue("WordPress");
            shirts.Enqueue("Code School");

            Console.WriteLine("After enqueuing, count = " + shirts.Count);

            var item1 = shirts.Dequeue();
            Console.WriteLine("\r\nRemoving " + item1);

            var item2 = shirts.Peek();
            Console.WriteLine("Peeking   " + item2);

            Console.WriteLine("\r\nEnumerating:");
            foreach (var item in shirts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\r\nAfter enumerating, count = " + shirts.Count);
        }
    }
}
