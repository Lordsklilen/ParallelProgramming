using System.Threading.Tasks;

namespace ParallelProgramming.Core
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var basic = new BasicParallel();
            var asynchronous = new AsynchronousParallel();
            var taskExample = new ParallelProgramming();
            var tpl = new ThreadParallelLibrary();
            //basic.ThreadExample();
            //basic.ThreadPoolExample();
            //asynchronous.SynchronousExample();
            //await asynchronous.AynchronousExample();
            //taskExample.TaskRunExample();
            tpl.ForeachExample();
            tpl.ParallelForeachExample();

        }
    }
}
