using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming.Core
{
    public static class TaskExample
    {
        // Normal Task.Run with thread from threadpool
        public static void Example()
        {
            Thread thread = Thread.CurrentThread;
            var param = "parameter";
            var t = Task.Run(() =>
            {
                Console.WriteLine($"Parameter: {param} Thread ID: {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(2000).Wait();
                Console.WriteLine($"Minor task ended");
            });
            Console.WriteLine($"Waiting for result. ThreadId: {thread.ManagedThreadId}");
            t.Wait();
            Console.WriteLine($"Tasks done");
        }

        //Long running task 
        public static void ExampleLongRunning()
        {
            Thread thread = Thread.CurrentThread;
            var ct = new CancellationToken();
            Task t = Task.Factory.StartNew(async () =>
            {
                while (!ct.IsCancellationRequested)
                {
                    await Task.Delay(500);
                }
            }, ct, TaskCreationOptions.LongRunning, TaskScheduler.Default)
                .Unwrap();

            Console.WriteLine($"Waiting for result. ThreadId: {thread.ManagedThreadId}");
            t.Wait();
            Console.WriteLine($"Tasks done");
        }
    }
}
