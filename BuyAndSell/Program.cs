﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyAndSell
{
    public static class Program
    {

        public static readonly List<string> AllShirtNames = 
            new List<string> {"technologyhour", "Code School", "jDays", "buddhistgeeks", "iGeek", "Big Nerd Ranch"};

        static void Main()
        {
            var controller = new StockController();
            var workDay = new TimeSpan(0, 0, 4);

            var t1 = Task.Run(() => new SalesPerson("Sahil").Work(controller, workDay));
            var t2 = Task.Run(() => new SalesPerson("Peter").Work(controller, workDay));
            var t3 = Task.Run(() => new SalesPerson("Juliette").Work(controller, workDay));
            var t4 = Task.Run(() => new SalesPerson("Xavier").Work(controller, workDay));
            var t5 = Task.Run(() => new SalesPerson("Ken").Work(controller, workDay));

            Task.WaitAll(t1, t2, t3, t4, t5);
            controller.DisplayStatus();
        }
    }
}
