using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalesBonuses
{
    public class ToDoQueue
    {
        private readonly BlockingCollection<Trade> _queue = new BlockingCollection<Trade>(new ConcurrentQueue<Trade>());
        private readonly StaffLogForBonuses _staffLogs;

        public ToDoQueue(StaffLogForBonuses staffResults)
        {
            _staffLogs = staffResults;
        }

        public void AddTrade(Trade transaction)
        {
            _queue.Add(transaction);
        }

        public void CompleteAdding()
        {
            _queue.CompleteAdding();
        }

        public void MonitorAndLogTrades()
        {
            while (true)
            {
                try
                {
                    var nextTransaction = _queue.Take();
                    _staffLogs.ProcessTrade(nextTransaction);
                    Console.WriteLine("Processing transaction from " + nextTransaction.Person.Name);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }
    }
}
