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

            //Basic.ThreadExample();
            //Basic.ThreadPoolExample();

            //Utils.ExecutionTime(new Action(ParallelFor.Example));
            //Utils.ExecutionTime(new Action(ParallelFor.ParallelExample));

            //Utils.ExecutionTime(new Action(ParallelForeach.Example));
            //Utils.ExecutionTime(new Action(ParallelForeach.ParallelExample));

            //await TaskExample.Example();
            //await TaskExample.ExampleLongRunning();

            //Utils.ExecutionTime(new Action(PLINQ.Example));
            //Utils.ExecutionTime(new Action(PLINQ.ParallelExample));
            //Utils.ExecutionTime(new Action(PLINQ.ParallelOrderedExample));
        }
    }
}
