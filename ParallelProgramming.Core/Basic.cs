using System;
using System.Threading;

namespace ParallelProgramming.Core
{
    public static class Basic
    {
        public static void ThreadExample()
        {
            Console.WriteLine($"Main thread, Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.Start();
            t.Join();
            Console.WriteLine($"Main thread exits.Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void ThreadProc()
        {
            Console.WriteLine($"ThreadProc, Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
        }

        public static void ThreadPoolExample()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));
            }
            Console.WriteLine("Main thread does some work, then sleeps.");
            Thread.Sleep(1000);
            Console.WriteLine($"Main thread exits, Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void ThreadProc(object stateInfo)
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine(
                $"Background: {thread.IsBackground}, " +
                $"Thread Pool: {thread.IsThreadPoolThread}, " +
                $"Thread ID: {thread.ManagedThreadId}");
            Thread.Sleep(10);
        }
    }
}
