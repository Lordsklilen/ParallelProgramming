using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ParallelProgramming.Core
{
    public static class Utils
    {
        public static bool IsPrime(int number)
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

        public static void ExecutionTime(Action method)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            method();
            sw.Stop();
            Console.WriteLine($"{method.Method.Name} ElapsedMilliseconds {sw.ElapsedMilliseconds}");
        }

        public static async Task ExecutionTimeAsync(Func<Task> method)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            await method();
            sw.Stop();
            Console.WriteLine($"{method.Method.Name} Elapsed Milliseconds {sw.ElapsedMilliseconds}");
        }
    }
}
