using System;
using System.Collections.Generic;

namespace EnumerateDictionary
{
    public static class Program
    {
        static void Main()
        {
            var stock = new Dictionary<string, int>
            {
                {"jDays", 0},
                { "Code School", 0},
                { "Buddhist Geeks", 0}
            };

            foreach (var shirt in stock)
            {
                stock["jDays"] += 1;
                Console.WriteLine(shirt.Key + ": " + shirt.Value);
            }
        }
    }
}
