using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
namespace Dynamic_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run<Fibonacci>();
            var summary = BenchmarkRunner.Run<KnapsackProblem>();
        }
    }



}
