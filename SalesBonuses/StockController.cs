using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalesBonuses
{
    public class StockController
    {
        ConcurrentDictionary<string, int> _stock = new ConcurrentDictionary<string, int>();
        private int _totalQuantityBought;
        private int _totalQuantitySold;
        private ToDoQueue _toDoQueue;

        public StockController(ToDoQueue bonusCalculator)
        {
            _toDoQueue = bonusCalculator;
        }

        public void BuyStock(SalesPerson person, string item, int quantity)
        {
            _stock.AddOrUpdate(item, quantity, (key, value) => value + quantity);
            Interlocked.Add(ref _totalQuantityBought, quantity);
            _toDoQueue.AddTrade(new Trade(person, -quantity));
        }

        public bool TrySellItem(SalesPerson person, string item)
        {
            var success = false;
            _stock.AddOrUpdate(item,
                itemName => { success = false; return 0; },
                (itemName, value) =>
                {
                    if (value == 0)
                    {
                        success = false;
                        return 0;
                    }
                    success = true;
                    return value - 1;
                });
            if (success)
            {
                Interlocked.Increment(ref _totalQuantitySold);
                _toDoQueue.AddTrade(new Trade(person, 1));
            }
            return success;
        }

        public void DisplayStatus()
        {
            var totalStock = _stock.Values.Sum();
            Console.WriteLine("\r\nBought = {0:n0}", _totalQuantityBought);
            Console.WriteLine("Sold   = {0:n0}", _totalQuantitySold);
            Console.WriteLine("Stock  = {0:n0}", totalStock);

            var error = totalStock + _totalQuantitySold - _totalQuantityBought;
            if (error == 0)
                Console.WriteLine("Stock levels match");
            else
                Console.WriteLine("Error in stock level: " + error);

            Console.WriteLine("\r\nStock levels by item:");
            foreach (var itemName in Program.AllShirtNames)
            {
                var stockLevel = _stock.GetOrAdd(itemName, 0);
                Console.WriteLine("{0,-30}: {1:n0}", itemName, stockLevel);
            }
        }
    }
}
