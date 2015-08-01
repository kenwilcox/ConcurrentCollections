﻿using System;
using System.Threading;

namespace BuyAndSell
{
    public class SalesPerson
    {
        public string Name { get; private set; }

        public SalesPerson(string id)
        {
            Name = id;
        }

        public void Work(StockController stockController, TimeSpan workDay)
        {
            Random rand = new Random(Name.GetHashCode());
            DateTime start = DateTime.Now;
            while (DateTime.Now - start < workDay)
            {
                Thread.Sleep(rand.Next(100));
                bool buy = (rand.Next(6) == 0);
                string itemName = Program.AllShirtNames[rand.Next((Program.AllShirtNames.Count))];
                if (buy)
                {
                    int quantity = rand.Next(9) + 1;
                    stockController.BuyStock(itemName, quantity);
                    DisplayPurchase(itemName, quantity);
                }
                else
                {
                    bool success = stockController.TrySellItem(itemName);
                    DisplaySaleAttempt(success, itemName);
                }
            }
            Console.WriteLine("SalesPerson {0} signing off", Name);
        }

        private void DisplaySaleAttempt(bool success, string itemName)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            if(success)
                Console.WriteLine("Thread {0}: {1} sold {2}", threadId, Name, itemName);
            else
                Console.WriteLine("Thread {0}: {1}: Out of stock of {2}", threadId, Name, itemName);
        }

        private void DisplayPurchase(string itemName, int quantity)
        {
            Console.WriteLine("Thread {0}: {1} bought {2} of {3}", Thread.CurrentThread.ManagedThreadId, Name, quantity, itemName);
        }
    }
}
