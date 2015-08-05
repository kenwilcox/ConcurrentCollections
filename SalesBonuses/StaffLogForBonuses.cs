using System;
using System.Collections.Concurrent;
using System.Threading;

namespace SalesBonuses
{
    public class StaffLogForBonuses
    {
        private readonly ConcurrentDictionary<SalesPerson, int> _salesByPerson = new ConcurrentDictionary<SalesPerson, int>(); 
        private readonly ConcurrentDictionary<SalesPerson, int> _purchasesByPerson = new ConcurrentDictionary<SalesPerson, int>();

        public void ProcessTrade(Trade sale)
        {
            //Thread.Sleep(300);
            if (sale.QuantitySold > 0)
                _salesByPerson.AddOrUpdate(sale.Person, sale.QuantitySold, (key, value) => value + sale.QuantitySold);
            else
                _purchasesByPerson.AddOrUpdate(sale.Person, -sale.QuantitySold, (key, value) => value - sale.QuantitySold);
        }

        public void DisplayReport(SalesPerson[] people)
        {
            Console.WriteLine();
            Console.WriteLine("Transactions by salesperson:");
            foreach (var person in people)
            {
                var sales = _salesByPerson.GetOrAdd(person, 0);
                var purchases = _purchasesByPerson.GetOrAdd(person, 0);
                Console.WriteLine("{0,15} sold {1,3:n0}, bought {2,3:n0} items, total {3:n0}", person.Name, sales, purchases, sales + purchases);
            }
        }
    }
}
