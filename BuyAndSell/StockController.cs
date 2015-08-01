using System.Collections.Concurrent;
using System.Threading;

namespace BuyAndSell
{
    public class StockController
    {
        private readonly ConcurrentDictionary<string, int> _stock = new ConcurrentDictionary<string, int>();
        private int _totalQuantityBought;
        private int _totalQuantitySold;

        public void BuyStock(string item, int quantity)
        {
            _stock.AddOrUpdate(item, quantity, (key, oldValue) => oldValue + quantity);
            Interlocked.Add(ref _totalQuantityBought, quantity);
        }

        public bool TrySellItem(string item)
        {
            var success = false;
            _stock.AddOrUpdate(item,
                itemName => { success = false; return 0;}, 
                (itemName, oldValue) =>
                {
                    if (oldValue == 0)
                    {
                        success = false;
                        return 0;
                    }
                    success = true;
                    return oldValue - 1;
                });
            if (success) Interlocked.Increment(ref _totalQuantitySold);
            return success;
        }

        public static void DisplayStatus()
        {
            
        }
    }
}
