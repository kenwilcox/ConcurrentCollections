using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBonuses
{
    public static class Program
    {
        public static readonly List<string> AllShirtNames = new List<string>
        {
            "technologyhour", "Code School", "jDays", "buddhistgeeks", "iGeek"
        };

        static void Main(string[] args)
        {
            var staffLogs = new StaffLogForBonuses();
            var toDoQueue = new ToDoQueue(staffLogs);

            SalesPerson[] people =
            {
                new SalesPerson("Sahil"),
                new SalesPerson("Peter"),
                new SalesPerson("Juliette"),
                new SalesPerson("Xavier")
            };

            var controller = new StockController(toDoQueue);
            var workDay = new TimeSpan(0, 0, 1);

            var t1 = Task.Run(() => people[0].Work(controller, workDay));
            var t2 = Task.Run(() => people[1].Work(controller, workDay));
            var t3 = Task.Run(() => people[2].Work(controller, workDay));
            var t4 = Task.Run(() => people[3].Work(controller, workDay));

            var bonusLogger = Task.Run(() => toDoQueue.MonitorAndLogTrades());
            var bonusLogger2 = Task.Run(() => toDoQueue.MonitorAndLogTrades());

            Task.WaitAll(t1, t2, t3, t4);
            toDoQueue.CompleteAdding();
            Task.WaitAll(bonusLogger, bonusLogger2);

            controller.DisplayStatus();
            staffLogs.DisplayReport(people);
        }
    }
}
