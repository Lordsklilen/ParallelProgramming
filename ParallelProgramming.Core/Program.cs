using System;
using System.Threading.Tasks;

namespace ParallelProgramming.Core
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Utils.ExecutionTime(new Action(Asynchronous.SynchronousExample));
            await Utils.ExecutionTimeAsync(Asynchronous.AsynchronousExample);

            //TaskExample.Example();

            //ParallelFor.Example();
            //ParallelFor.ParallelExample();

            //ParallelForeach.Example();
            //ParallelForeach.ParallelExample();

            //PLINQ.Example();
            //PLINQ.ParallelExample();
        }
    }
}
