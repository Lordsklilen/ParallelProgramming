using System;
using System.Diagnostics;
using System.Linq;

namespace ParallelProgramming.Core
{
    public static class PLINQ
    {
        private const int size = 10000000;
        public static void Example()
        {
            Stopwatch sw = new Stopwatch();
            var collection = Enumerable.Range(1, size);
            sw.Start();
            var result = collection
                .Select(x => Utils.IsPrime(x))
                .ToArray();
            sw.Stop();
            Console.WriteLine($"Linq time: {sw.ElapsedMilliseconds}ms");
        }

        public static void ParallelExample()
        {
            Stopwatch sw = new Stopwatch();
            var collection = Enumerable.Range(1, size);
            sw.Start();
            var result = collection
                .AsParallel()
                .Select(x => Utils.IsPrime(x))
                .ToArray();
            sw.Stop();
            Console.WriteLine($"Parallel Linq time: {sw.ElapsedMilliseconds}ms");
        }
    }
}
