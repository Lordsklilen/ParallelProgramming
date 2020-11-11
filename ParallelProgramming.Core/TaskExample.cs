using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming.Core
{
    public class TaskExample
    {
        public void TaskRunExample()
        {
            Thread thread = Thread.CurrentThread;
            var param = "parameter";
            var t = Task.Run(() => ShowThreadInfo(param));
            Console.WriteLine($"MainThread waiting for result. " +
                $"ThreadId: {thread.ManagedThreadId}");
            t.Wait();
            Console.WriteLine($"Task done");

        }

        void ShowThreadInfo(string param)
        {
            Console.WriteLine($"Parameter: {param} " +
                $"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Task.Delay(2000).Wait();
            Console.WriteLine($"Task ended: {param} " +
                $"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
