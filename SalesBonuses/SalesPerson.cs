using System;
using System.Threading;

namespace SalesBonuses
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
            var rand = new Random(Name.GetHashCode());
            var start = DateTime.Now;
            while (DateTime.Now - start < workDay)
            {
                //Thread.Sleep(rand.Next(100));
                var buy = (rand.Next(6) == 0);
                var itemName = Program.AllShirtNames[rand.Next((Program.AllShirtNames.Count))];
                if (buy)
                {
                    var quantity = rand.Next(9) + 1;
                    stockController.BuyStock(this, itemName, quantity);
                    DisplayPurchase(itemName, quantity);
                }
                else
                {
                    var success = stockController.TrySellItem(this, itemName);
                    DisplaySaleAttempt(success, itemName);
                }
            }
            Console.WriteLine("SalesPerson {0} signing off", Name);
        }

        private void DisplaySaleAttempt(bool success, string itemName)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine(success ? "Thread {0}: {1} sold {2}" : "Thread {0}: {1}: Out of stock of {2}", threadId, Name, itemName);
        }

        private void DisplayPurchase(string itemName, int quantity)
        {
            Console.WriteLine("Thread {0}: {1} bought {2} of {3}", Thread.CurrentThread.ManagedThreadId, Name, quantity, itemName);
        }
    }
}
