using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConcurrentCollections
{
	class Program
	{
		static void Main(string[] args)
		{
			var orders = new Queue<string>();
			PlaceOrders(orders, "Mark");
			PlaceOrders(orders, "Ramdevi");

			foreach(string order in orders) 
			{
				Console.WriteLine("ORDER: " + order);
			}
		}

		static void PlaceOrders(Queue<string> orders, string customerName)
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
