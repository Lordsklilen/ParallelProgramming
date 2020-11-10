using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelProgramming.Core
{
    public class ThreadParallelLibrary
    {
        private const int size = 10000000;

        public void ForeachExample()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var collection = Enumerable.Range(1, size);
            foreach (var item in collection)
            {
                IsPrime(item);
            }
            sw.Stop();
            Console.WriteLine($"Foreach time: {sw.ElapsedMilliseconds}ms");
        }

        public void ParallelForeachExample()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var collection = Enumerable.Range(1, size);
            Parallel.ForEach(collection,
            currentElement =>
            {
                IsPrime(currentElement);
            });
            sw.Stop();
            Console.WriteLine($"Parallel Foreach time: {sw.ElapsedMilliseconds}ms");
        }

        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
