using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelProgramming.Core
{
    public class ThreadParallelLibrary
    {
        private const int size = 10000000;

        public void ForExample()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < size; i++)
            {
                IsPrime(i);
            }
            sw.Stop();
            Console.WriteLine($"For time: {sw.ElapsedMilliseconds}ms");
        }

        public void ParallelForExample()
        {
            Stopwatch sw = new Stopwatch();
            var collection = Enumerable.Range(1, size).ToArray();
            sw.Start();
            Parallel.For(0, collection.Length,
              index =>
              {
                  IsPrime(index);

              });
            Console.WriteLine($"Parallel For time: {sw.ElapsedMilliseconds}ms");
        }



        public void ForeachExample()
        {
            Stopwatch sw = new Stopwatch();
            var collection = Enumerable.Range(1, size);
            sw.Start();
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
            var collection = Enumerable.Range(1, size);
            sw.Start();
            Parallel.ForEach(collection,
            element =>
            {
                IsPrime(element);
            });
            sw.Stop();
            Console.WriteLine($"Parallel Foreach time: {sw.ElapsedMilliseconds}ms");
        }
        public void LINQExample()
        {
            Stopwatch sw = new Stopwatch();
            var collection = Enumerable.Range(1, size);
            sw.Start();
            var result = collection
                .Select(x => IsPrime(x))
                .ToArray();
            sw.Stop();
            Console.WriteLine($"Linq time: {sw.ElapsedMilliseconds}ms");
        }

        public void PLINQExample()
        {
            Stopwatch sw = new Stopwatch();
            var collection = Enumerable.Range(1, size);
            sw.Start();
            var result = collection
                .AsParallel()
                .Select(x => IsPrime(x))
                .ToArray();
            sw.Stop();
            Console.WriteLine($"Parallel Linq time: {sw.ElapsedMilliseconds}ms");
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
