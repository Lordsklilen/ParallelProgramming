using System;
using System.Threading;

namespace ParallelProgramming.Core
{
    public class BasicParallel
    {
        public void ThreadExample()
        {
            Console.WriteLine("Main thread: Start a second thread.");
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine($"Main thread Thread ID: {thread.ManagedThreadId}");
                Thread.Sleep(10);
            }
            Console.WriteLine("Main thread: t.Join()");
            t.Join();
            Console.WriteLine("Main thread exits.");
        }

        public void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine($"ThreadProc, Thread ID: {thread.ManagedThreadId}");
                Thread.Sleep(10);
            }
        }

        public void ThreadPoolExample()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));
            }
            Console.WriteLine("Main thread does some work, then sleeps.");
            Thread.Sleep(1000);
            Console.WriteLine("Main thread exits.");
        }

        static void ThreadProc(object stateInfo)
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
