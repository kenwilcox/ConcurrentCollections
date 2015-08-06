
namespace Benchmarks
{
    public static class Worker
    {
        public static int DoSomethingTimeConsuming()
        {
            var total = 0;
            for (var i = 0; i < 1000; i++)
                total += i;
            return total;
        }
    }
}
