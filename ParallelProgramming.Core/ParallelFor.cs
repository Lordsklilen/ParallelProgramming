using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelProgramming.Core
{
    public static class ParallelForeach
    {
        private const int size = 10000000;

        public static void Example()
        {
            Stopwatch sw = new Stopwatch();
            var collection = Enumerable.Range(1, size);
            sw.Start();
            foreach (var item in collection)
            {
                Utils.IsPrime(item);
            }
            sw.Stop();
            Console.WriteLine($"Foreach time: {sw.ElapsedMilliseconds}ms");
        }

        public static void ParallelExample()
        {
            Stopwatch sw = new Stopwatch();
            var collection = Enumerable.Range(1, size);
            sw.Start();
            Parallel.ForEach(collection,
            element =>
            {
                Utils.IsPrime(element);
            });
            sw.Stop();
            Console.WriteLine($"Parallel Foreach time: {sw.ElapsedMilliseconds}ms");
        }
    }
}
