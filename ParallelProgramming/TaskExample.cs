﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public static class TaskExample
    {
        // Task.Run with thread from threadpool
        public static async Task Example()
        {
            var param = "parameter";
            Task t = Task.Run(async () =>
            {
                Console.WriteLine($"Parameter: {param} Thread ID: {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(2000);
                Console.WriteLine($"Minor task ended");
            });
            Console.WriteLine($"Awaiting for result. ThreadId: { Thread.CurrentThread.ManagedThreadId}");
            await t;
            Console.WriteLine($"Tasks done, ThreadId: { Thread.CurrentThread.ManagedThreadId}");
        }

        //Long running task 
        public static async Task ExampleLongRunning()
        {            
            var cancelationToken = new CancellationToken();
            var counter = 0;
            Task t = Task.Factory.StartNew(async () =>
            {
                //while (!cancelationToken.IsCancellationRequested && counter < 5)
                //{
                //    Console.WriteLine($"Counter {counter} ThreadId: { Thread.CurrentThread.ManagedThreadId}");
                //    await Task.Delay(500);
                //    counter++;
                //}
                for (int i = 0; i < 100000000; i++)
                {
                    counter++;
                }
            }, cancelationToken,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default)
                .Unwrap();
            for (int i = 0; i < 100000000; i++)
            {
                counter--;
            }
            Console.WriteLine($"Awaiting for result. ThreadId: { Thread.CurrentThread.ManagedThreadId}");
            await t;
            Console.WriteLine($"Tasks done, counter: {counter},ThreadId: { Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
