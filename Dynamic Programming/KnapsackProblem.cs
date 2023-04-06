using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynamic_Programming
{
    public class KnapsackProblem
    {
        int[] val = new int[] { 60, 100, 120, 50, 55, 11, 23, 17, 33, 10, 22, 19, 99, 81, 32, 77, 81, 89, 1, 4, 76, 12, 29, 32,  13, 32, 98, 11, 44, 0};
        int[] wt = new int[]  { 5 ,   7,   3,  7,  8,  9, 12,  1,  4,  5, 12, 14, 56, 34, 22, 50, 12, 10, 4, 3, 50, 12, 54, 13, 100,  6, 34, 87, 91, 12};
        int W = 100;
        int n = 30;


        [Benchmark(Baseline = true)]
        public int BenchMarkKnapSackBruteForce()
        {
            return KnapSackBruteForce(W , wt , val , n);
        }

        [Benchmark]
        public int BenchMarkKnapSackTabulation()
        {
            return KnapSackTabulation(W, wt, val, n);
        }

        [Benchmark]
        public int BenchMarkKnapSackMemoization()
        {
            return KnapSackMemoization(W, wt, val, n);
        }


        private int KnapSackBruteForce(int W, int[] wt, int[] val, int n)
        {
            if (n == 0 || W == 0)
                return 0;

            if (wt[n - 1] > W)
                return KnapSackBruteForce(W, wt, val, n - 1);

            else
                return Math.Max(val[n - 1] + KnapSackBruteForce(W - wt[n - 1], wt, val, n - 1), KnapSackBruteForce(W, wt, val, n - 1));
        }

        private int KnapSackTabulation(int W, int[] wt, int[] val, int n)
        {
            int i, w;
            int[,] K = new int[n + 1, W + 1];

 
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;

                    else if (wt[i - 1] <= w)
                        K[i, w] = Math.Max(val[i - 1] + K[i - 1, w - wt[i - 1]],K[i - 1, w]);

                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[n, W];
        }

        private int KnapSackMemoization(int W, int[] wt, int[] val, int N)
        {

            int[,] dp = new int[N + 1, W + 1];

            for (int i = 0; i < N + 1; i++)
                for (int j = 0; j < W + 1; j++)
                    dp[i, j] = -1;

            return KnapSackRec(W, wt, val, N, dp);
        }
        private int KnapSackRec(int W, int[] wt, int[] val,int n, int[,] dp)
        {
            if (n == 0 || W == 0)
                return 0;
            if (dp[n, W] != -1)
                return dp[n, W];
            if (wt[n - 1] > W)
                return dp[n, W] = KnapSackRec(W, wt, val, n - 1, dp);

            else
                return dp[n, W] = Math.Max((val[n - 1] + KnapSackRec(W - wt[n - 1], wt, val, n - 1, dp)) , KnapSackRec(W, wt, val, n - 1, dp));
        }
    }
}
