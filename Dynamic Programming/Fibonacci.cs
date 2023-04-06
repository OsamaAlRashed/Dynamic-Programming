using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic_Programming
{
    //[SimpleJob(RunStrategy.ColdStart, launchCount: 1, warmupCount: 5, targetCount: 5, id: "FastAndDirtyJob")]
    public class Fibonacci
    {
        [Params(10, 15, 20, 25 , 30)]
        public int n;
        [Benchmark(Baseline = true)]
        public int BenchMarkRecursionFib()
        {
            return RecursionFib(n);
        }

        [Benchmark]
        public int BenchMarkMemoizationFib()
        {
            Initialize();
            return MemoizationFib(n);
        }

        [Benchmark]
        public int BenchMarkTabulationFib()
        {
            return TabulationFib(n);
        }

        private int RecursionFib(int n)
        {
            if (n <= 1)
                return n;

            return RecursionFib(n - 1) + RecursionFib(n - 2);
        }

        private static int MAX = 100;
        private static int NIL = -1;
        private static int[] lookup = new int[MAX];
        private void Initialize()
        {
            for (int i = 0; i < MAX; i++)
                lookup[i] = NIL;
        }

        private int MemoizationFib(int n)
        {
            if (lookup[n] == NIL)
            {
                if (n <= 1)
                    lookup[n] = n;
                else
                    lookup[n] = MemoizationFib(n - 1) + MemoizationFib(n - 2);
            }
            return lookup[n];
        }

        private int TabulationFib(int n)
        {
            int[] f = new int[n + 1];
            f[0] = 0;
            f[1] = 1;
            for (int i = 2; i <= n; i++)
                f[i] = f[i - 1] + f[i - 2];
            return f[n];
        }
    }
}
