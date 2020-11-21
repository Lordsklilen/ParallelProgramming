using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelProgramming.Core
{
    public static class ParallelFor
    {
        private const int size = 10000000;

        public static void Example()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < size; i++)
            {
                Utils.IsPrime(i);
            }
            sw.Stop();
            Console.WriteLine($"For time: {sw.ElapsedMilliseconds}ms");
        }

        public static void ParallelExample()
        {
            Stopwatch sw = new Stopwatch();
            var collection = Enumerable.Range(1, size).ToArray();
            sw.Start();
            Parallel.For(0, collection.Length,
              index =>
              {
                  Utils.IsPrime(index);

              });
            Console.WriteLine($"Parallel For time: {sw.ElapsedMilliseconds}ms");
        }


    }
}
