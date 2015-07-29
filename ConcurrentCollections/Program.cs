using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace ConcurrentCollections
{
	class Program
	{
		static void Main(string[] args)
		{
			var orders = new ConcurrentQueue<string>();
			var task1 = Task.Run(() => PlaceOrders(orders, "Mark"));
			var task2 = Task.Run(() => PlaceOrders(orders, "Ramdevi"));
			Task.WaitAll(task1, task2);

			foreach(string order in orders) 
			{
				Console.WriteLine("ORDER: " + order);
			}
		}

		static void PlaceOrders(ConcurrentQueue<string> orders, string customerName)
		{
			for (int i = 0; i < 5; i++)
			{
				Thread.Sleep(1);
				var orderName = string.Format("{0} wants t-shirt {1}", customerName, i + 1);
				orders.Enqueue(orderName);
			}
		}
	}
}
