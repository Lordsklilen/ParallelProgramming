using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming.Core
{
    public class ParallelProgramming
    {
        public void TaskRunExample()
        {
            var param = "parameter";
            var t = Task.Run(() => ShowThreadInfo(param));
            t.Wait();
        }

        void ShowThreadInfo(string s)
        {
            Console.WriteLine($"Parameter: {s} " +
                $"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
