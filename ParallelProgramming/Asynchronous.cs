using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public static class Asynchronous
    {
        public static void SynchronousExample()
        {
            int resultJob_1 = Job_1();
            string resultJob_2 = Job_2();
            Console.WriteLine($"Results{resultJob_1}, {resultJob_2}," +
                $" Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }

        public static int Job_1()
        {
            Console.WriteLine($"Job_1 started Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Task.Delay(3000).Wait();
            Console.WriteLine($"Job_1 ended Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return 3000;
        }

        public static string Job_2()
        {
            Console.WriteLine($"Job_2 started Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Task.Delay(4000).Wait();
            Console.WriteLine($"Job_2 ended Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return "Job_2 done";
        }

        public static async Task AsynchronousExample()
        {
            Task<int> j1 = Job_1Async();
            Task<string> j2 = Job_2Async();
            int resultJob_1 = await j1;
            string resultJob_2 = await j2;
            Console.WriteLine($"Results{resultJob_1}, {resultJob_2}, " +
                $"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }

        public static async Task<int> Job_1Async()
        {
            Console.WriteLine($"Job_1 started Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(3000);
            Console.WriteLine($"Job_1 ended Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return 3000;
        }

        public static async Task<string> Job_2Async()
        {
            Console.WriteLine($"Job_2 started Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(4000);
            Console.WriteLine($"Job_2 ended Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return "Job_2 done";
        }
    }
}

