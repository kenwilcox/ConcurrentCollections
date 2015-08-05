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
        private readonly ConcurrentQueue<Trade> _queue = new ConcurrentQueue<Trade>();
        private bool _workingDayComplete = false;
        private readonly StaffLogForBonuses _staffLogs;

        public ToDoQueue(StaffLogForBonuses staffResults)
        {
            _staffLogs = staffResults;
        }

        public void AddTrade(Trade transaction)
        {
            _queue.Enqueue(transaction);
        }

        public void CompleteAdding()
        {
            _workingDayComplete = true;
        }

        public void MonitorAndLogTrades()
        {
            while (true)
            {
                Trade nexTrade;
                var done = _queue.TryDequeue(out nexTrade);
                
                if (done)
                {
                    _staffLogs.ProcessTrade(nextTrade);
                    Console.WriteLine("Processing transaction from " + nexTrade.Person.Name);
                }
                else if (_workingDayComplete)
                {
                    Console.WriteLine("No more sales to log - exiting");
                    return;
                }
                else
                {
                    Console.WriteLine("No transactions availble");
                    Thread.Sleep(500);
                }
            }
        }
    }
}
