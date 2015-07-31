using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace ConcurrentCollections
{
	public static class Program
	{
		static void Main()
		{
			var orders = new ConcurrentQueue<string>();
			var task1 = Task.Run(() => PlaceOrders(orders, "Mark"));
			var task2 = Task.Run(() => PlaceOrders(orders, "Ramdevi"));
			Task.WaitAll(task1, task2);

			foreach(string order in orders) 
				Console.WriteLine("ORDER: " + order);

			Parallel.ForEach(orders, ProcessOrder);
		}

		static void ProcessOrder(string order)
		{
			Console.WriteLine("Processing Order: " + order);
		}

		static void PlaceOrders(ConcurrentQueue<string> orders, string customerName)
		{
			for (var i = 0; i < 50; i++)
			{
				Thread.Sleep(1);
				var orderName = string.Format("{0} wants t-shirt {1}", customerName, i + 1);
				orders.Enqueue(orderName);
			}
		}
	}
}
