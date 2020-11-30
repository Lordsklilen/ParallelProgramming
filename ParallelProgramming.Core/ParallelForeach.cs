using System.Linq;
using System.Threading.Tasks;

namespace ParallelProgramming.Core
{
    public static class ParallelFor
    {
        private const int size = 10000000;

        public static void Example()
        {
            var collection = Enumerable.Range(1, size);
            for (var i = 0; i < collection.Count(); i++)
            {
                Utils.IsPrime(i);
            }
        }

        public static void ParallelExample()
        {
            var collection = Enumerable.Range(1, size);
            Parallel.For(0, collection.Count(),
              index =>
              {
                  Utils.IsPrime(index);

              });
        }
    }
}
