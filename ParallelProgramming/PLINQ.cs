﻿using System.Linq;

namespace ParallelProgramming
{
    public static class PLINQ
    {
        private const int size = 10000000;
        public static void Example()
        {
            var collection = Enumerable.Range(1, size);
            var result = collection
                .Select(x => Utils.IsPrime(x))
                .ToArray();
        }

        public static void ParallelExample()
        {
            var collection = Enumerable.Range(1, size);
            var result = collection
                .AsParallel()
                .Select(x => Utils.IsPrime(x))
                .ToArray();
        }

        public static void ParallelOrderedExample()
        {
            var collection = Enumerable.Range(1, size);
            var result = collection
                .AsParallel()
                .AsOrdered()
                .Select(x => Utils.IsPrime(x))
                .ToArray();
        }
    }
}
