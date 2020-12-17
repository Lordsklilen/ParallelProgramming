using System.Linq;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public static class ParallelForeach
    {
        private const int size = 10000000;

        public static void Example()
        {
            var collection = Enumerable.Range(1, size);
            foreach (var item in collection)
            {
                Utils.IsPrime(item);
            }
        }

        public static void ParallelExample()
        {
            var collection = Enumerable.Range(1, size);
            Parallel.ForEach(collection,
                
            element =>
            {
                Utils.IsPrime(element);
            }
            );
        }
    }
}
